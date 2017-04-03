﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eidss.openapi.contract
{
    /// <summary>
    /// Farm
    /// </summary>
    public class Farm 
    {
        /// <summary>
        /// A unique number of the record
        /// </summary>
        public long RecordID { get; set; }

        /// <summary>
        /// A unique number of the root record. Root record contains information about the particular object. When there is a need to link a case to the same root object (e.g. same patient) information is copied from the root object to the new object created for this case.
        /// </summary>
        public long RootRecordID { get; set; }

        /// <summary>
        /// A number that is assigned to the individual farm and automatically generated by EIDSS. The number appears when the farm information is saved first time. 
        /// </summary>
        public string FarmID { get; set; }

        /// <summary>
        /// Owner First name
        /// </summary>
        public string OwnerFirstName { get; set; }

        /// <summary>
        /// Owner Second name
        /// </summary>
        public string OwnerMiddleName { get; set; }

        /// <summary>
        /// Owner Last name
        /// </summary>
        public string OwnerLastName { get; set; }

        /// <summary>
        /// The e-mail address that is used for business correspondence by the owner or farm manager.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The number for the fax that is used for business by the owner or farm manager.
        /// </summary>
        public string Fax { get; set; }

        /// <summary>
        /// Name of the farm, if one is known
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Phone number of the farm owner.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Denotes the size of the farming operation.  User selects from Backyard or village household (&lt;50), Commercial small scale (50-500), Commercial medium scale (500-5000), Commercial large scale (>5000)<br/>
        /// Reference type: Farm Ownership Type<br/>
        /// Reference number: 19000065
        /// </summary>
        public Reference Type { get; set; }

        /// <summary>
        /// Address
        /// </summary>
        public Address Address { get; set; }
    }
}