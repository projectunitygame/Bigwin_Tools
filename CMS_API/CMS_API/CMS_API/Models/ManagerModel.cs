using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api_cms.Models
{
    public class ManagerModel
    {
        private CustomerModel customerModel;

        public CustomerModel CustomerModel { get => CustomerModel.Instance; set => customerModel = value; }
        public OrderModel OrderModel { get => OrderModel.Instance; set => orderModel = value; }
        public AgencyModel AgencyModel { get => AgencyModel.Instance; set => agencyModel = value; }
        public GameAcountModel GameAcountModel { get => GameAcountModel.Instance; set => gameAcountModel = value; }

        private OrderModel orderModel;


        private AgencyModel agencyModel;

        private GameAcountModel gameAcountModel;
    }
}