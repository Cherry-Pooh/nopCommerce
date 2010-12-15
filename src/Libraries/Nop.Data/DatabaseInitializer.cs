//------------------------------------------------------------------------------
// The contents of this file are subject to the nopCommerce Public License Version 1.0 ("License"); you may not use this file except in compliance with the License.
// You may obtain a copy of the License at  http://www.nopCommerce.com/License.aspx. 
// 
// Software distributed under the License is distributed on an "AS IS" basis, WITHOUT WARRANTY OF ANY KIND, either express or implied. 
// See the License for the specific language governing rights and limitations under the License.
// 
// The Original Code is nopCommerce.
// The Initial Developer of the Original Code is NopSolutions.
// All Rights Reserved.
// 
// Contributor(s): _______. 
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Data.Entity.Database;
using Nop.Core.Domain;


namespace Nop.Data
{
    /// <summary>
    /// Database initializer
    /// </summary>
    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<NopObjectContext>
    {
        protected override void Seed(NopObjectContext context)
        {
            //settings
            var settings = new List<Setting>
            {
                new Setting
                {
                    Name = "TestSetting1",
                    Value = "Value1",
                    Description = string.Empty
                },
                new Setting
                {
                    Name = "TestSetting2",
                    Value = "Value2",
                    Description = string.Empty
                }
            };
            settings.ForEach(s => context.Settings.Add(s));
            context.SaveChanges();

            base.Seed(context);
        }
    }
}