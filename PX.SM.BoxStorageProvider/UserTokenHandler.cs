﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PX.Data;
using System.IO;
using System.Web.Compilation;
using PX.Common;
using Box.V2.Auth;

namespace PX.SM.BoxStorageProvider
{
    public class UserTokenHandler : PXGraph<UserTokenHandler>
    {
        public BoxUserTokens GetCurrentUser()
        {
            return PXSelect<BoxUserTokens, Where<BoxUserTokens.userID, Equal<Current<AccessInfo.userID>>>>.Select(this);
        }

        public void SessionAuthenticated(object sender, SessionAuthenticatedEventArgs e)
        {
            PXTrace.WriteInformation($"Box Session authenticated a: {e.Session.AccessToken} r: {e.Session.RefreshToken} Expires in: {e.Session.ExpiresIn}");

            // We use a separate connection to ensure that the token gets persisted to the DB, regardless of any transaction rollback.
            // It could potentially happen that the token needs to get refreshed while a file is uploaded, but that this upload ultimately gets rolled back due to another
            // error later during the caller graph persisting process. If we use the current connection scope we have no control over this update.
            using (new PXConnectionScope())
            {
                PXDatabase.Update<BoxUserTokens>(
                            new PXDataFieldAssign<BoxUserTokens.accessToken>(PXDbType.NVarChar, 255, PX.Data.PXDB3DesCryphStringAttribute.Encrypt(e.Session.AccessToken)),
                            new PXDataFieldAssign<BoxUserTokens.refreshToken>(PXDbType.NVarChar, 255, PX.Data.PXDB3DesCryphStringAttribute.Encrypt(e.Session.RefreshToken)),
                            new PXDataFieldAssign<BoxUserTokens.refreshTokenDate>(PXDbType.DateTime, 8, PXTimeZoneInfo.UtcNow),
                            new PXDataFieldRestrict<BoxUserTokens.userID>(PXDbType.UniqueIdentifier, 16, this.Accessinfo.UserID));
            }
        }

        public void SessionInvalidated(object sender, EventArgs e)
        {
            PXTrace.WriteInformation("Box Session invalidated.");

            //2020-03-01 Disabling. That might help address concurrency issues when two threads are updating the tokens at the same time
            //Clear out stored token if any.
            //using (new PXConnectionScope())
            //{
            //    PXDatabase.Update<BoxUserTokens>(
            //                new PXDataFieldAssign<BoxUserTokens.accessToken>(PXDbType.NVarChar, 255, null),
            //                new PXDataFieldAssign<BoxUserTokens.refreshToken>(PXDbType.NVarChar, 255, null),
            //                new PXDataFieldRestrict<BoxUserTokens.userID>(PXDbType.UniqueIdentifier, 16, this.Accessinfo.UserID));
            //}

            throw new PXException(Messages.BoxUserNotFoundOrTokensExpired);
        }
    }
}
