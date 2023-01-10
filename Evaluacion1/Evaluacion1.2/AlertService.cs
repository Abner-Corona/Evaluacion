using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluacion1._2
{
    public class AlertService
    {
        //private readonly AlertDAO storage = new ();
        private readonly AlertDAO _storage ;

        public AlertService(IAlertDAO storage)
        {
            _storage = (AlertDAO)storage;
        }
        public Guid RaiseAlert()
        {
            //return this.storage.AddAlert(DateTime.Now);
            return this._storage.AddAlert(DateTime.Now);
        }
        public DateTime GetAlertTime(Guid id)
        {
           // return this.storage.GetAlert(id);
            return this._storage.GetAlert(id);
        }
    }
}
