using AccessSystem.Models.Object;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AccessSystem
{
    internal class ConnectTo1C
    {
        #region private fields

        private readonly string _addressGetListRoles = "/getlistroles";
        private readonly string _addressGetListUsers = "/getlistusers";
        private readonly string _addressSetRolesUser = "/setrolesuser";

        private Base _base = null;

        private string _url;
        private string _user;
        private string _password;

        public Body body = new Body();
        private string _token = String.Empty;

        #endregion

        internal ConnectTo1C(Base @base)
        {
            _base = @base;
            InitializeObject();
        }

        #region public methods

        public List<Base> GetListRoles()
        {
            try
            {
                return null;
            }
            catch (Exception ex)
            {
                string textMessage = $"Ошибка выполнения операции получения списка ролей.\n" +
                    $"Причина:\n" +
                    $"{ex.Message}";

                Dialog.ShowMessage(textMessage);
                return null;
            }
        }

        public List<Base> GetListUsers()
        {
            try
            {
                return null;
            }
            catch (Exception ex)
            {
                string textMessage = $"Ошибка выполнения операции получения списка пользователей.\n" +
                    $"Причина:\n" +
                    $"{ex.Message}";

                Dialog.ShowMessage(textMessage);
                return null;
            }
        }

        public bool SetRolesUser(Request request)
        {
            try
            {
                if (_base == null)
                    throw new NotImplementedException();
#warning need fix
                //else if (request.Base != _base)
                //    throw new NotImplementedException();

                //string bodyRequest = ;

                //string resultString = ;

                //var result = ;

                //if (result.Success)
                //    return true;
                //else
                    return false;
            }
            catch (Exception ex)
            {
                string textMessage = $"Ошибка выполнения операции установки ролей.\n" +
                    $"Причина:\n" +
                    $"{ex.Message}";

                Dialog.ShowMessage(textMessage);
                return false;
            }
        }

        #endregion

        #region http methods

        private string CallGet(string getPostfix, int timeout = 10)
        {
            string textResponse = String.Empty;

            if (body == null)
            {
                _user = "http";
                _password = "http";
            }
            else
            {
                _user = body.user;
                _password = body.password;
            }

            WebRequest webRequest = WebRequest.Create(GetUrl(getPostfix));
            webRequest.Credentials = new NetworkCredential(_user, _password);

            webRequest.Method = "get";
            SetParameterWebRequest(ref webRequest, timeout);

            using (WebResponse response = webRequest.GetResponse())
            {
                Stream stream = response.GetResponseStream();

                if (stream.CanRead)
                {
                    StreamReader streamReader = new StreamReader(stream);
                    textResponse = streamReader.ReadToEnd();
                }
            }

            return textResponse;
        }

        private string CallPost(string postPostfix, string textBody = "", int timeout = 10)
        {
            string textResponse = String.Empty;

            if (body == null)
            {
                _user = "http";
                _password = "http";
            }
            else
            {
                _user = body.user;
                _password = body.password;
            }

            try
            {
                WebRequest webRequest = WebRequest.Create(GetUrl(postPostfix));
                webRequest.Credentials = new NetworkCredential(_user, _password);

                webRequest.Method = "post";
                SetParameterWebRequest(ref webRequest, timeout);

                AddHeaderToken(ref webRequest);

                if (string.IsNullOrWhiteSpace(textBody))
                    webRequest.ContentLength = 0;
                else
                {
                    byte[] bodyByte = Encoding.UTF8.GetBytes(textBody);

                    webRequest.ContentLength = bodyByte.Length;

                    using (Stream requestStream = webRequest.GetRequestStream())
                    {
                        requestStream.Write(bodyByte, 0, bodyByte.Length);
                        requestStream.Close();
                    }
                }

                using (WebResponse response = webRequest.GetResponse())
                {
                    Stream stream = response.GetResponseStream();

                    if (stream.CanRead)
                    {
                        using (StreamReader streamReader = new StreamReader(stream))
                        {
                            textResponse = streamReader.ReadToEnd();
                            streamReader.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                textResponse = ex.Message;
            }

            return textResponse;

        }

        #endregion

        #region other http methods

        private void AddHeaderToken(ref WebRequest webRequest)
        {
            if (!string.IsNullOrWhiteSpace(_token))
                webRequest.Headers.Add("token", _token);
        }

        private void SetParameterWebRequest(ref WebRequest webRequest, int timeout)
        {
            webRequest.Timeout = timeout * 1000;
            webRequest.ContentType = "application/json";
        }

        #endregion

        #region private methods

        private void InitializeObject()
        {
            _url = _base.ConnectionURI;
            if (String.IsNullOrWhiteSpace(_url))
                throw new NotImplementedException();
        }

        private string GetUrl(string postfix)
        {
            return $"{_url}{postfix}";
        }

        #endregion

        public class Body
        {
            public string user = String.Empty;
            public string password = String.Empty;
        }

    }
}
