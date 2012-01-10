﻿/* 
MagentoApi CSharp Library
Copyright (c) 2009 ez.newsletter, LLC <ezmagento@ez-llc.com>
ez.newsletter - Advanced Targeted Email Marketing for Magento Store Owners
http://www.ez-llc.com/studio/site/eznewsletter/email-marketing-info-magento-customer-management.aspx
Contributions By:
	Keith Smyth keith@kkl.com.au

XML-RPC.NET library
Copyright (c) 2001-2006, Charles Cook <charlescook@cookcomputing.com>

Permission is hereby granted, free of charge, to any person 
obtaining a copy of this software and associated documentation 
files (the "Software"), to deal in the Software without restriction, 
including without limitation the rights to use, copy, modify, merge, 
publish, distribute, sublicense, and/or sell copies of the Software, 
and to permit persons to whom the Software is furnished to do so, 
subject to the following conditions:

The above copyright notice and this permission notice shall be 
included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, 
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES 
OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND 
NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT 
HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, 
WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, 
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
DEALINGS IN THE SOFTWARE.
*/

using System;
using CookComputing.XmlRpc;

namespace Ez.Newsletter.MagentoApi
{
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class OrderAddress
    {
        #region Private Member Variables
        private string _shipment_id;
        private string _shipping_lastname;
        private string _order_increment_id;
        private string _is_active;
        private string _shipping_firstname;
        private string _parent_id;
        private string _store_id;
        private string _created_at;
        private string _increment_id;
        private string _updated_at;
        private string _total_qty;
        private string _order_id;
        private string _order_created_at;
        private string _shipping_address_id;

        private string _region_id;
        private string _address_type;
        private string _firstname;
        private string _lastname;
        private string _company;
        private string _street;
        private string _city;
        private string _region;
        private string _postcode;
        private string _country_id;
        private string _telephone;
        private string _fax;
        private string _address_id;
        #endregion

        public string city
        {
            get { return _city; }
            set { _city = value; }
        }
        public string region_id
        {
            get { return _region_id; }
            set { _region_id = value; }
        }
        public string address_type
        {
            get { return _address_type; }
            set { _address_type = value; }
        }
        public string firstname
        {
            get { return _firstname; }
            set { _firstname = value; }
        }
        public string lastname
        {
            get { return _lastname; }
            set { _lastname = value; }
        }
        public string company
        {
            get { return _company; }
            set { _company = value; }
        }
        public string street
        {
            get { return _street; }
            set { _street = value; }
        }
        public string region
        {
            get { return _region; }
            set { _region = value; }
        }
        public string postcode
        {
            get { return _postcode; }
            set { _postcode = value; }
        }
        public string country_id
        {
            get { return _country_id; }
            set { _country_id = value; }
        }
        public string telephone
        {
            get { return _telephone; }
            set { _telephone = value; }
        }
        public string fax
        {
            get { return _fax; }
            set { _fax = value; }
        }
        public string address_id
        {
            get { return _address_id; }
            set { _address_id = value; }
        }


        #region Private Properties

        #endregion

        #region Public Properties
        public string shipment_id
        {
            get { return _shipment_id; }
            set { _shipment_id = value; }
        }
        public string shipping_lastname
        {
            get { return _shipping_lastname; }
            set { _shipping_lastname = value; }
        }
        public string order_increment_id
        {
            get { return _order_increment_id; }
            set { _order_increment_id = value; }
        }
        public string is_active
        {
            get { return _is_active; }
            set { _is_active = value; }
        }
        public string shipping_firstname
        {
            get { return _shipping_firstname; }
            set { _shipping_firstname = value; }
        }
        public string parent_id
        {
            get { return _parent_id; }
            set { _parent_id = value; }
        }
        public string store_id
        {
            get { return _store_id; }
            set { _store_id = value; }
        }
        public string created_at
        {
            get { return _created_at; }
            set { _created_at = value; }
        }
        public string increment_id
        {
            get { return _increment_id; }
            set { _increment_id = value; }
        }
        public string updated_at
        {
            get { return _updated_at; }
            set { _updated_at = value; }
        }
        public string total_qty
        {
            get { return _total_qty; }
            set { _total_qty = value; }
        }
        public string order_id
        {
            get { return _order_id; }
            set { _order_id = value; }
        }
        public string order_created_at
        {
            get { return _order_created_at; }
            set { _order_created_at = value; }
        }
        public string shipping_address_id
        {
            get { return _shipping_address_id; }
            set { _shipping_address_id = value; }
        }
        #endregion
    }
}
