using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Security.Principal;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Text;
using System.Web;
using bv.common.Core;
using bv.model.Model.Core;
using eidss.model.Core;
using eidss.openapi.bll.Bll;
using eidss.openapi.contract;
using eidss.openapi.bll.Exceptions;
using eidss.openapi.web.Utils;
using eidss.model.Enums;
using log4net;

namespace eidss.openapi.web
{
    /// <summary>
    /// Soap service for EIDSS Open API
    /// </summary>
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class SoapService : ISoapService
    {
        #region helpers
        protected void AuthCheck(string permission)
        {
            if (EidssUserContext.User == null || EidssUserContext.User.ID == null)
                throw new AuthRequiredException();
            if (permission != null && EidssUserContext.User.HasPermission(permission) == false)
                throw new AuthAccessException();
        }

        private const string CLASS_NAME = "SoapService";

        protected void call<I1>(string name, I1 i1, Action<I1> f, params string[] p)
        {
            Logger.Instance.LogStart(CLASS_NAME, name);
            try
            {
                if (p != null)
                    foreach (string c in p)
                        AuthCheck(c);
                Logger.Instance.LogInfo(CLASS_NAME, name, i1);
                f(i1);
            }
            catch (OpenApiException e)
            {
                Logger.Instance.LogError(CLASS_NAME, name, e.ErrorCode, e);
                throw new FaultException(new FaultReason(e.Message), new FaultCode(e.ErrorCode));
            }
            catch (Exception e)
            {
                Logger.Instance.LogError(CLASS_NAME, name, OpenApiErrorCode.G0001.ToString(), e);
                throw new FaultException(new FaultReason(e.Message), new FaultCode(OpenApiErrorCode.G0001.ToString()));
            }
            finally
            {
                Logger.Instance.LogFinish(CLASS_NAME, name);
            }
        }

        protected void call<I1, I2>(string name, I1 i1, I2 i2, Action<I1, I2> f, params string[] p)
        {
            Logger.Instance.LogStart(CLASS_NAME, name);
            try
            {
                if (p != null)
                    foreach (string c in p)
                        AuthCheck(c);
                Logger.Instance.LogInfo(CLASS_NAME, name, i1, i2);
                f(i1, i2);
            }
            catch (OpenApiException e)
            {
                Logger.Instance.LogError(CLASS_NAME, name, e.ErrorCode, e);
                throw new FaultException(new FaultReason(e.Message), new FaultCode(e.ErrorCode));
            }
            catch (Exception e)
            {
                Logger.Instance.LogError(CLASS_NAME, name, OpenApiErrorCode.G0001.ToString(), e);
                throw new FaultException(new FaultReason(e.Message), new FaultCode(OpenApiErrorCode.G0001.ToString()));
            }
            finally
            {
                Logger.Instance.LogFinish(CLASS_NAME, name);
            }
        }

        protected O call<I1, O>(string name, I1 i1, Func<I1, O> f, params string[] p)
        {
            Logger.Instance.LogStart(CLASS_NAME, name);
            try
            {
                if (p != null)
                    foreach(string c in p)
                        AuthCheck(c);
                Logger.Instance.LogInfo(CLASS_NAME, name, i1);
                return Logger.Instance.LogInfoReturn(CLASS_NAME, name, f(i1));
            }
            catch (OpenApiException e)
            {
                Logger.Instance.LogError(CLASS_NAME, name, e.ErrorCode, e);
                throw new FaultException(new FaultReason(e.Message), new FaultCode(e.ErrorCode));
            }
            catch (Exception e)
            {
                Logger.Instance.LogError(CLASS_NAME, name, OpenApiErrorCode.G0001.ToString(), e);
                throw new FaultException(new FaultReason(e.Message), new FaultCode(OpenApiErrorCode.G0001.ToString()));
            }
            finally
            {
                Logger.Instance.LogFinish(CLASS_NAME, name);
            }
        }

        protected O call<I1, I2, O>(string name, I1 i1, I2 i2, Func<I1, I2, O> f, params string[] p)
        {
            Logger.Instance.LogStart(CLASS_NAME, name);
            try
            {
                if (p != null)
                    foreach (string c in p)
                        AuthCheck(c);
                Logger.Instance.LogInfo(CLASS_NAME, name, i1);
                return Logger.Instance.LogInfoReturn(CLASS_NAME, name, f(i1, i2));
            }
            catch (OpenApiException e)
            {
                Logger.Instance.LogError(CLASS_NAME, name, e.ErrorCode, e);
                throw new FaultException(new FaultReason(e.Message), new FaultCode(e.ErrorCode));
            }
            catch (Exception e)
            {
                Logger.Instance.LogError(CLASS_NAME, name, OpenApiErrorCode.G0001.ToString(), e);
                throw new FaultException(new FaultReason(e.Message), new FaultCode(OpenApiErrorCode.G0001.ToString()));
            }
            finally
            {
                Logger.Instance.LogFinish(CLASS_NAME, name);
            }
        }
        #endregion

        #region Login
        /// <summary>Login to the EIDSS</summary>
        /// <param name="value">Login parameters</param>
        /// <exception cref="OpenApiErrorCode.A0001">User login can't be empty</exception>
        /// <exception cref="OpenApiErrorCode.A0002">User with such login/password is not found</exception>
        /// <exception cref="OpenApiErrorCode.A0003">The database version is absent or in incorrect format</exception>
        /// <exception cref="OpenApiErrorCode.A0004">Login is locked</exception>
        /// <exception cref="OpenApiErrorCode.A0005">Password is expired</exception>
        /// <exception cref="OpenApiErrorCode.A0006">Language is not supported</exception>
        /// <exception cref="OpenApiErrorCode.A0007">External system is not supported</exception>
        /// <exception cref="OpenApiErrorCode.A0008">Login is failed (general login error)</exception>
        /// <exception cref="OpenApiErrorCode.A0009">Login is required</exception>
        /// <exception cref="OpenApiErrorCode.A0010">Access is denied</exception>
        /// <example><code>
        /// // C#
        /// try {
        ///     var client = new SoapServiceClient();
        ///     client.Login(new Login() { organization = "organization", user = "username", password = "password", language = "en" });
        /// }
        /// catch(FaultException e) {
        ///     Console.WriteLine("{0} - {1}", e.Code.Name, e.Reason.ToString());
        /// }
        /// </code></example>
        public void Login(Login value)
        {
            call("Login", value, LoginBll.Authorize);
        }
        #endregion
        #region HumanCase
        /// <summary>Create new Human Case</summary>
        /// <param name="value">Human Case for create</param>
        /// <returns>Created Human Case</returns>
        /// <exception cref="OpenApiErrorCode.A0009">Login is required</exception>
        /// <exception cref="OpenApiErrorCode.A0010">Access is denied</exception>
        /// <exception cref="OpenApiErrorCode.M0001">Validation object is failed</exception>
        /// <exception cref="OpenApiErrorCode.M0002">Reference is not found</exception>
        /// <exception cref="OpenApiErrorCode.M0004">An attempt to set a readonly field was occured</exception>
        /// <example><code>
        /// // C#
        /// // TODO
        /// </code></example>
        public HumanCase HumanCaseCreate(HumanCase value)
        {
            return call("HumanCaseCreate", value, c => HumanCaseBll.Create(c), PermissionHelper.InsertPermission(EIDSSPermissionObject.HumanCase));
        }

        /// <summary>Update existing Human Case</summary>
        /// <param name="id">Identifier of Human Case</param>
        /// <param name="value">Updating Human Case</param>
        /// <returns>Updated Human Case</returns>
        /// <exception cref="OpenApiErrorCode.A0009">Login is required</exception>
        /// <exception cref="OpenApiErrorCode.A0010">Access is denied</exception>
        /// <exception cref="OpenApiErrorCode.M0001">Validation object is failed</exception>
        /// <exception cref="OpenApiErrorCode.M0002">Reference is not found</exception>
        /// <exception cref="OpenApiErrorCode.M0003">Human Case with specified id is not found</exception>
        /// <exception cref="OpenApiErrorCode.M0004">An attempt to set a readonly field was occured</exception>
        /// <example><code>
        /// // C#
        /// // TODO
        /// </code></example>
        public HumanCase HumanCaseUpdate(long id, HumanCase value)
        {
            return call("HumanCaseUpdate", id, value, (c1, c2) => HumanCaseBll.Update(c1, c2), PermissionHelper.UpdatePermission(EIDSSPermissionObject.HumanCase));
        }

        /// <summary>Get Human Case by it's identifier</summary>
        /// <param name="id">Identifier of Human Case</param>
        /// <returns>Human Case</returns>
        /// <exception cref="OpenApiErrorCode.A0009">Login is required</exception>
        /// <exception cref="OpenApiErrorCode.A0010">Access is denied</exception>
        /// <exception cref="OpenApiErrorCode.M0003">Human Case with specified id is not found</exception>
        /// <example><code>
        /// // C#
        /// // TODO
        /// </code></example>
        public HumanCase HumanCaseGet(long id)
        {
            return call("HumanCaseGet", id, c => HumanCaseBll.Select(c), PermissionHelper.SelectPermission(EIDSSPermissionObject.HumanCase));
        }

        /// <summary>Delete Human Case by it's identifier</summary>
        /// <param name="id">Identifier of Human Case</param>
        /// <exception cref="OpenApiErrorCode.A0009">Login is required</exception>
        /// <exception cref="OpenApiErrorCode.A0010">Access is denied</exception>
        /// <exception cref="OpenApiErrorCode.M0001">Validation object is failed</exception>
        /// <exception cref="OpenApiErrorCode.M0003">Human Case with specified id is not found</exception>
        /// <example><code>
        /// // C#
        /// // TODO
        /// </code></example>
        public void HumanCaseDelete(long id)
        {
            call("HumanCaseDelete", id, HumanCaseBll.Delete, PermissionHelper.DeletePermission(EIDSSPermissionObject.HumanCase));
        }

        /// <summary>Get list of brief information of Human Case</summary>
        /// <param name="filter">Filter</param>
        /// <returns>List of brief information of Human Case</returns>
        /// <exception cref="OpenApiErrorCode.A0009">Login is required</exception>
        /// <exception cref="OpenApiErrorCode.A0010">Access is denied</exception>
        /// <example><code>
        /// // C#
        /// try {
        ///     var client = new SoapServiceClient();
        ///     client.Login(new Login() { organization = "organization", user = "username", password = "password", language = "en" });
        /// 
        ///     var filter = new HumanCaseListFilter() { CaseID = "HGETBTB0130005" };
        ///     var list = client.HumanCaseList(filter);
        ///     foreach (var p in list)
        ///         Console.WriteLine("{0}", p.CaseID);
        /// }
        /// catch(FaultException e) {
        ///     Console.WriteLine("{0} - {1}", e.Code.Name, e.Reason.ToString());
        /// }
        /// </code></example>
        public List<HumanCaseListItem> HumanCaseList(HumanCaseListFilter filter)
        {
            return new List<HumanCaseListItem>(
                call("HumanCaseList", filter, c => HumanCaseBll.Select(c), PermissionHelper.SelectPermission(EIDSSPermissionObject.HumanCase))
                );
        }
        #endregion
        #region HumanCaseSample
        /// <summary>Create new Human Case Sample</summary>
        /// <param name="idHumanCase">Identifier of Human Case</param>
        /// <param name="value">Human Case Sample for create</param>
        /// <returns>Created Human Case Sample</returns>
        /// <exception cref="OpenApiErrorCode.A0009">Login is required</exception>
        /// <exception cref="OpenApiErrorCode.A0010">Access is denied</exception>
        /// <exception cref="OpenApiErrorCode.M0001">Validation object is failed</exception>
        /// <exception cref="OpenApiErrorCode.M0002">Reference is not found</exception>
        /// <exception cref="OpenApiErrorCode.M0003">Human Case with specified id is not found</exception>
        /// <exception cref="OpenApiErrorCode.M0004">An attempt to set a readonly field was occured</exception>
        /// <example><code>
        /// // C#
        /// // TODO
        /// </code></example>
        public Sample HumanCaseSampleCreate(long idHumanCase, Sample value)
        {
            return call("HumanCaseSampleCreate", idHumanCase, value, (c1, c2) => HumanCaseSampleBll.Create(c1, c2), PermissionHelper.UpdatePermission(EIDSSPermissionObject.HumanCase));
        }

        /// <summary>Delete Human Case Sample by it's identifier</summary>
        /// <param name="idHumanCase">Identifier of Human Case</param>
        /// <param name="id">Identifier of Human Case Sample</param>
        /// <exception cref="OpenApiErrorCode.A0009">Login is required</exception>
        /// <exception cref="OpenApiErrorCode.A0010">Access is denied</exception>
        /// <exception cref="OpenApiErrorCode.M0001">Validation object is failed</exception>
        /// <exception cref="OpenApiErrorCode.M0003">Human Case with specified id is not found</exception>
        /// <exception cref="OpenApiErrorCode.M0003">Human Case Sample with specified id is not found</exception>
        /// <example><code>
        /// // C#
        /// // TODO
        /// </code></example>
        public void HumanCaseSampleDelete(long idHumanCase, long id)
        {
            call("HumanCaseSampleDelete", idHumanCase, id, HumanCaseSampleBll.Delete, PermissionHelper.UpdatePermission(EIDSSPermissionObject.HumanCase));
        }
        #endregion
        #region HumanCaseTest
        public Test HumanCaseTestCreate(long idHumanCase, Test value)
        {
            return call("HumanCaseTestCreate", idHumanCase, value, (c1, c2) => HumanCaseTestBll.Create(c1, c2), PermissionHelper.UpdatePermission(EIDSSPermissionObject.HumanCase));
        }
        public void HumanCaseTestDelete(long idHumanCase, long id)
        {
            call("HumanCaseTestDelete", idHumanCase, id, HumanCaseTestBll.Delete, PermissionHelper.UpdatePermission(EIDSSPermissionObject.HumanCase));
        }
        #endregion
        #region HumanCaseTestInterpretation
        public TestInterpretation HumanCaseTestInterpretationCreate(long idHumanCase, TestInterpretation value)
        {
            return call("HumanCaseTestInterpretationCreate", idHumanCase, value, (c1, c2) => HumanCaseTestValidationBll.Create(c1, c2), PermissionHelper.UpdatePermission(EIDSSPermissionObject.HumanCase));
        }
        public void HumanCaseTestInterpretationDelete(long idHumanCase, long id)
        {
            call("HumanCaseTestInterpretationDelete", idHumanCase, id, HumanCaseTestValidationBll.Delete, PermissionHelper.UpdatePermission(EIDSSPermissionObject.HumanCase));
        }
        #endregion
        #region VetCase
        /// <summary>Create new Vet Case</summary>
        /// <param name="value">Vet Case for create</param>
        /// <returns>Created Vet Case</returns>
        /// <exception cref="OpenApiErrorCode.A0009">Login is required</exception>
        /// <exception cref="OpenApiErrorCode.A0010">Access is denied</exception>
        /// <exception cref="OpenApiErrorCode.M0001">Validation object is failed</exception>
        /// <exception cref="OpenApiErrorCode.M0002">Reference is not found</exception>
        /// <exception cref="OpenApiErrorCode.M0004">An attempt to set a readonly field was occured</exception>
        /// <example><code>
        /// // C#
        /// // TODO
        /// </code></example>
        public VetCase VetCaseCreate(VetCase value)
        {
            return call("VetCaseCreate", value, c => VetCaseBll.Create(c), PermissionHelper.InsertPermission(EIDSSPermissionObject.VetCase));
        }

        /// <summary>Update existing Vet Case</summary>
        /// <param name="id">Identifier of Vet Case</param>
        /// <param name="value">Updating Vet Case</param>
        /// <returns>Updated Vet Case</returns>
        /// <exception cref="OpenApiErrorCode.A0009">Login is required</exception>
        /// <exception cref="OpenApiErrorCode.A0010">Access is denied</exception>
        /// <exception cref="OpenApiErrorCode.M0001">Validation object is failed</exception>
        /// <exception cref="OpenApiErrorCode.M0002">Reference is not found</exception>
        /// <exception cref="OpenApiErrorCode.M0003">Vet Case with specified id is not found</exception>
        /// <exception cref="OpenApiErrorCode.M0004">An attempt to set a readonly field was occured</exception>
        /// <example><code>
        /// // C#
        /// // TODO
        /// </code></example>
        public VetCase VetCaseUpdate(long id, VetCase value)
        {
            return call("VetCaseUpdate", id, value, (c1, c2) => VetCaseBll.Update(c1, c2), PermissionHelper.UpdatePermission(EIDSSPermissionObject.VetCase));
        }

        /// <summary>Get Vet Case by it's identifier</summary>
        /// <param name="id">Identifier of Vet Case</param>
        /// <returns>Vet Case</returns>
        /// <exception cref="OpenApiErrorCode.A0009">Login is required</exception>
        /// <exception cref="OpenApiErrorCode.A0010">Access is denied</exception>
        /// <exception cref="OpenApiErrorCode.M0003">Vet Case with specified id is not found</exception>
        /// <example><code>
        /// // C#
        /// // TODO
        /// </code></example>
        public VetCase VetCaseGet(long id)
        {
            return call("VetCaseGet", id, c => VetCaseBll.Select(c), PermissionHelper.SelectPermission(EIDSSPermissionObject.VetCase));
        }

        /// <summary>Delete Vet Case by it's identifier</summary>
        /// <param name="id">Identifier of Vet Case</param>
        /// <exception cref="OpenApiErrorCode.A0009">Login is required</exception>
        /// <exception cref="OpenApiErrorCode.A0010">Access is denied</exception>
        /// <exception cref="OpenApiErrorCode.M0001">Validation object is failed</exception>
        /// <exception cref="OpenApiErrorCode.M0003">Vet Case with specified id is not found</exception>
        /// <example><code>
        /// // C#
        /// // TODO
        /// </code></example>
        public void VetCaseDelete(long id)
        {
            call("VetCaseDelete", id, VetCaseBll.Delete, PermissionHelper.DeletePermission(EIDSSPermissionObject.VetCase));
        }

        /// <summary>Get list of brief information of Vet Case</summary>
        /// <param name="filter">Filter</param>
        /// <returns>List of brief information of Vet Case</returns>
        /// <exception cref="OpenApiErrorCode.A0009">Login is required</exception>
        /// <exception cref="OpenApiErrorCode.A0010">Access is denied</exception>
        /// <example><code>
        /// // C#
        /// try {
        ///     var client = new SoapServiceClient();
        ///     client.Login(new Login() { organization = "organization", user = "username", password = "password", language = "en" });
        /// 
        ///     var filter = new VetCaseListFilter() { CaseID = "VGETBTB0130005" };
        ///     var list = client.VetCaseList(filter);
        ///     foreach (var p in list)
        ///         Console.WriteLine("{0}", p.CaseID);
        /// }
        /// catch(FaultException e) {
        ///     Console.WriteLine("{0} - {1}", e.Code.Name, e.Reason.ToString());
        /// }
        /// </code></example>
        public List<VetCaseListItem> VetCaseList(VetCaseListFilter filter)
        {
            return new List<VetCaseListItem>(call("VetCaseList", filter, c => VetCaseBll.Select(c), PermissionHelper.SelectPermission(EIDSSPermissionObject.VetCase)));
        }
        #endregion
        #region VetCaseSample
        /// <summary>Create new Vet Case Sample</summary>
        /// <param name="idVetCase">Identifier of Vet Case</param>
        /// <param name="value">Vet Case Sample for create</param>
        /// <returns>Created Vet Case Sample</returns>
        /// <exception cref="OpenApiErrorCode.A0009">Login is required</exception>
        /// <exception cref="OpenApiErrorCode.A0010">Access is denied</exception>
        /// <exception cref="OpenApiErrorCode.M0001">Validation object is failed</exception>
        /// <exception cref="OpenApiErrorCode.M0002">Reference is not found</exception>
        /// <exception cref="OpenApiErrorCode.M0003">Vet Case with specified id is not found</exception>
        /// <exception cref="OpenApiErrorCode.M0004">An attempt to set a readonly field was occured</exception>
        /// <example><code>
        /// // C#
        /// // TODO
        /// </code></example>
        public Sample VetCaseSampleCreate(long idVetCase, Sample value)
        {
            return call("VetCaseSampleCreate", idVetCase, value, (c1, c2) => VetCaseSampleBll.Create(c1, c2), PermissionHelper.UpdatePermission(EIDSSPermissionObject.VetCase));
        }

        /// <summary>Delete Vet Case Sample by it's identifier</summary>
        /// <param name="idVetCase">Identifier of Vet Case</param>
        /// <param name="id">Identifier of Vet Case Sample</param>
        /// <exception cref="OpenApiErrorCode.A0009">Login is required</exception>
        /// <exception cref="OpenApiErrorCode.A0010">Access is denied</exception>
        /// <exception cref="OpenApiErrorCode.M0001">Validation object is failed</exception>
        /// <exception cref="OpenApiErrorCode.M0003">Vet Case with specified id is not found</exception>
        /// <exception cref="OpenApiErrorCode.M0003">Vet Case Sample with specified id is not found</exception>
        /// <example><code>
        /// // C#
        /// // TODO
        /// </code></example>
        public void VetCaseSampleDelete(long idVetCase, long id)
        {
            call("VetCaseSampleDelete", idVetCase, id, VetCaseSampleBll.Delete, PermissionHelper.UpdatePermission(EIDSSPermissionObject.VetCase));
        }
        #endregion
        #region VetCaseTest
        public Test VetCaseTestCreate(long idVetCase, Test value)
        {
            return call("VetCaseTestCreate", idVetCase, value, (c1, c2) => VetCaseTestBll.Create(c1, c2), PermissionHelper.UpdatePermission(EIDSSPermissionObject.VetCase));
        }
        public void VetCaseTestDelete(long idVetCase, long id)
        {
            call("VetCaseTestDelete", idVetCase, id, VetCaseTestBll.Delete, PermissionHelper.UpdatePermission(EIDSSPermissionObject.VetCase));
        }
        #endregion
        #region VetCaseTestInterpretation
        public TestInterpretation VetCaseTestInterpretationCreate(long idVetCase, TestInterpretation value)
        {
            return call("VetCaseTestInterpretationCreate", idVetCase, value, (c1, c2) => VetCaseTestValidationBll.Create(c1, c2), PermissionHelper.UpdatePermission(EIDSSPermissionObject.VetCase));
        }
        public void VetCaseTestInterpretationDelete(long idVetCase, long id)
        {
            call("VetCaseTestInterpretationDelete", idVetCase, id, VetCaseTestValidationBll.Delete, PermissionHelper.UpdatePermission(EIDSSPermissionObject.VetCase));
        }
        #endregion
        #region VetCasePensideTest
        public PensideTest VetCasePensideTestCreate(long idVetCase, PensideTest value)
        {
            return call("VetCasePensideTestCreate", idVetCase, value, (c1, c2) => VetCasePensideTestBll.Create(c1, c2), PermissionHelper.UpdatePermission(EIDSSPermissionObject.VetCase));
        }
        public void VetCasePensideTestDelete(long idVetCase, long id)
        {
            call("VetCasePensideTestDelete", idVetCase, id, VetCasePensideTestBll.Delete, PermissionHelper.UpdatePermission(EIDSSPermissionObject.VetCase));
        }
        #endregion
        #region Farm
        public Farm FarmGet(long id)
        {
            return call("FarmGet", id, c => FarmBll.Select(c), PermissionHelper.SelectPermission(EIDSSPermissionObject.AccessToFarmData));
        }
        public List<FarmListItem> FarmList(FarmListFilter filter)
        {
            return new List<FarmListItem>(
                call("FarmList", filter, c => FarmBll.Select(c), PermissionHelper.SelectPermission(EIDSSPermissionObject.AccessToFarmData))
                );
        }
        #endregion
        #region Organization
        /// <summary>Create new Organization</summary>
        /// <param name="value">Organization for create</param>
        /// <returns>Created Organization</returns>
        /// <exception cref="OpenApiErrorCode.A0009">Login is required</exception>
        /// <exception cref="OpenApiErrorCode.A0010">Access is denied</exception>
        /// <exception cref="OpenApiErrorCode.M0001">Validation object is failed</exception>
        /// <exception cref="OpenApiErrorCode.M0002">Reference is not found</exception>
        /// <exception cref="OpenApiErrorCode.M0004">An attempt to set a readonly field was occured</exception>
        /// <example><code>
        /// // C#
        /// // TODO
        /// </code></example>
        public Organization OrganizationCreate(Organization value)
        {
            return call("OrganizationCreate", value, c => OrganizationBll.Create(c), PermissionHelper.InsertPermission(EIDSSPermissionObject.Organization));
        }

        /// <summary>Update existing Organization</summary>
        /// <param name="id">Identifier of Organization</param>
        /// <param name="value">Updating Organization</param>
        /// <returns>Updated Organization</returns>
        /// <exception cref="OpenApiErrorCode.A0009">Login is required</exception>
        /// <exception cref="OpenApiErrorCode.A0010">Access is denied</exception>
        /// <exception cref="OpenApiErrorCode.M0001">Validation object is failed</exception>
        /// <exception cref="OpenApiErrorCode.M0002">Reference is not found</exception>
        /// <exception cref="OpenApiErrorCode.M0003">Organization with specified id is not found</exception>
        /// <exception cref="OpenApiErrorCode.M0004">An attempt to set a readonly field was occured</exception>
        /// <example><code>
        /// // C#
        /// // TODO
        /// </code></example>
        public Organization OrganizationUpdate(long id, Organization value)
        {
            return call("OrganizationUpdate", id, value, (c1, c2) => OrganizationBll.Update(c1, c2), PermissionHelper.UpdatePermission(EIDSSPermissionObject.Organization));
        }

        /// <summary>Get Organization by it's identifier</summary>
        /// <param name="id">Identifier of Organization</param>
        /// <returns>Organization</returns>
        /// <exception cref="OpenApiErrorCode.A0009">Login is required</exception>
        /// <exception cref="OpenApiErrorCode.A0010">Access is denied</exception>
        /// <exception cref="OpenApiErrorCode.M0003">Organization with specified id is not found</exception>
        /// <example><code>
        /// // C#
        /// // TODO
        /// </code></example>
        public Organization OrganizationGet(long id)
        {
            return call("OrganizationGet", id, c => OrganizationBll.Select(c), PermissionHelper.SelectPermission(EIDSSPermissionObject.Organization));
        }

        /// <summary>Delete Organization by it's identifier</summary>
        /// <param name="id">Identifier of Organization</param>
        /// <exception cref="OpenApiErrorCode.A0009">Login is required</exception>
        /// <exception cref="OpenApiErrorCode.A0010">Access is denied</exception>
        /// <exception cref="OpenApiErrorCode.M0001">Validation object is failed</exception>
        /// <exception cref="OpenApiErrorCode.M0003">Organization with specified id is not found</exception>
        /// <example><code>
        /// // C#
        /// // TODO
        /// </code></example>
        public void OrganizationDelete(long id)
        {
            call("OrganizationDelete", id, OrganizationBll.Delete, PermissionHelper.DeletePermission(EIDSSPermissionObject.Organization));
        }

        /// <summary>Get list of brief information of Organization</summary>
        /// <param name="filter">Filter</param>
        /// <returns>List of brief information of Organization</returns>
        /// <exception cref="OpenApiErrorCode.A0009">Login is required</exception>
        /// <exception cref="OpenApiErrorCode.A0010">Access is denied</exception>
        /// <example><code>
        /// // C#
        /// try {
        ///     var client = new SoapServiceClient();
        ///     client.Login(new Login() { organization = "organization", user = "username", password = "password", language = "en" });
        /// 
        ///     var filter = new OrganizationListFilter() { CaseID = "" };
        ///     var list = client.OrganizationList(filter);
        ///     foreach (var p in list)
        ///         Console.WriteLine("{0}", p);
        /// }
        /// catch(FaultException e) {
        ///     Console.WriteLine("{0} - {1}", e.Code.Name, e.Reason.ToString());
        /// }
        /// </code></example>
        public List<OrganizationListItem> OrganizationList(OrganizationListFilter filter)
        {
            return new List<OrganizationListItem>(
                call("OrganizationList", filter, c => OrganizationBll.Select(c), PermissionHelper.SelectPermission(EIDSSPermissionObject.Organization))
                );
        }
        #endregion
        #region OrganizationPerson
        /// <summary>Create new Person</summary>
        /// <param name="idOrganization">Identifier of Organization</param>
        /// <param name="value">Person for create</param>
        /// <returns>Created Person</returns>
        /// <exception cref="OpenApiErrorCode.A0009">Login is required</exception>
        /// <exception cref="OpenApiErrorCode.A0010">Access is denied</exception>
        /// <exception cref="OpenApiErrorCode.M0001">Validation object is failed</exception>
        /// <exception cref="OpenApiErrorCode.M0002">Reference is not found</exception>
        /// <exception cref="OpenApiErrorCode.M0003">Organization with specified id is not found</exception>
        /// <exception cref="OpenApiErrorCode.M0004">An attempt to set a readonly field was occured</exception>
        /// <example><code>
        /// // C#
        /// // TODO
        /// </code></example>
        public Person OrganizationPersonCreate(long idOrganization, Person value)
        {
            return call("OrganizationPersonCreate", idOrganization, value, (c1, c2) => OrganizationPersonBll.Create(c1, c2), PermissionHelper.UpdatePermission(EIDSSPermissionObject.Person));
        }

        /// <summary>Delete Person by it's identifier</summary>
        /// <param name="idOrganization">Identifier of Organization</param>
        /// <param name="id">Identifier of Person</param>
        /// <exception cref="OpenApiErrorCode.A0009">Login is required</exception>
        /// <exception cref="OpenApiErrorCode.A0010">Access is denied</exception>
        /// <exception cref="OpenApiErrorCode.M0001">Validation object is failed</exception>
        /// <exception cref="OpenApiErrorCode.M0003">Organization with specified id is not found</exception>
        /// <exception cref="OpenApiErrorCode.M0003">Person with specified id is not found</exception>
        /// <example><code>
        /// // C#
        /// // TODO
        /// </code></example>
        public void OrganizationPersonDelete(long idOrganization, long id)
        {
            call("OrganizationPersonDelete", idOrganization, id, OrganizationPersonBll.Delete, PermissionHelper.UpdatePermission(EIDSSPermissionObject.Person));
        }
        #endregion
        #region Patient
        public Patient PatientGet(long id)
        {
            return call("PatientGet", id, c => PatientBll.Select(c), PermissionHelper.SelectPermission(EIDSSPermissionObject.Patient));
        }
        public List<PatientListItem> PatientList(PatientListFilter filter)
        {
            return new List<PatientListItem>(
                call("PatientList", filter, c => PatientBll.Select(c), PermissionHelper.SelectPermission(EIDSSPermissionObject.Patient))
                );
        }
        #endregion
        #region Reference
        public List<Reference> ReferenceList(long type)
        {
            return new List<Reference>(
                call("ReferenceList", type, c => ReferenceBll.GetList(c), PermissionHelper.SelectPermission(EIDSSPermissionObject.Reference))
                );
        }
        public List<Diagnosis> DiagnosisList()
        {
            return new List<Diagnosis>(
                call("DiagnosisList", 0, c => ReferenceBll.GetDignosisList(), PermissionHelper.SelectPermission(EIDSSPermissionObject.Reference))
                );
        }
        public List<Reference> SampleTypeForDiagnosisList(int haCode, long diagnosis)
        {
            return new List<Reference>(
                call("SampleTypeForDiagnosisList", haCode, diagnosis, (c1, c2) => ReferenceBll.GetSampleTypeForDiagnosisList(c1, c2), PermissionHelper.SelectPermission(EIDSSPermissionObject.Reference))
                );
        }
        public List<GisReference> CountryList()
        {
            return new List<GisReference>(
                call("CountryList", 0, c => ReferenceBll.GetCountryList(), PermissionHelper.SelectPermission(EIDSSPermissionObject.GisReference))
                );
        }
        public List<GisReference> RegionList(long country)
        {
            return new List<GisReference>(
                call("RegionList", country, c => ReferenceBll.GetRegionList(country), PermissionHelper.SelectPermission(EIDSSPermissionObject.GisReference))
                );
        }
        public List<GisReference> RayonList(long region)
        {
            return new List<GisReference>(
                call("RayonList", region, c => ReferenceBll.GetRayonList(region), PermissionHelper.SelectPermission(EIDSSPermissionObject.GisReference))
                );
        }
        public List<GisReference> SettlementList(long rayon)
        {
            return new List<GisReference>(
                call("SettlementList", rayon, c => ReferenceBll.GetSettlementList(rayon), PermissionHelper.SelectPermission(EIDSSPermissionObject.GisReference))
                );
        }
        #endregion




    }

}
