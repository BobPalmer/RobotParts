using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Invoicing.Model;
using Invoicing.Persistance;
using Invoicing.Repository;

namespace Invoicing.TestHelpers
{
    public class FakePartsRepository : PartsRepository
    {
        public FakePartsRepository()
        {
            Dormouse.Core.Utilities.CreateSchema();
            LoadDemoData();
        }

        private void LoadDemoData()
        {
            var parts = GetDemoParts();
            foreach (var p in parts)
            {
                Create(p);
            }
        }

        private IList<Part> GetDemoParts()
        {
            var parts = new List<Part>();
            parts.Add(new Part {PartName = "Advanced Microcontroller", UnitPrice = 350M, UpfrontPercent = .1M});
            parts.Add(new Part {PartName = "Basic Microcontroller", UnitPrice = 125M, UpfrontPercent = .1M});
            parts.Add(new Part {PartName = "Articulated Tracks", UnitPrice = 2000M, UpfrontPercent = .25M,});
            parts.Add(new Part {PartName = "Hexapod base assembly", UnitPrice = 2500M, UpfrontPercent = .25M,});
            parts.Add(new Part {PartName = "All terrain wheels", UnitPrice = 800M, UpfrontPercent = .1M,});
            parts.Add(new Part {PartName = "Ruggedized 12vDC motor", UnitPrice = 1200M, UpfrontPercent = .25M,});
            parts.Add(new Part {PartName = "Mechanical arm assembly", UnitPrice = 750M, UpfrontPercent = .1M,});
            parts.Add(new Part {PartName = "Steel case sheathing", UnitPrice = 149M, UpfrontPercent = .1M,});
            parts.Add(new Part {PartName = "Infrared sensor array", UnitPrice = 325M, UpfrontPercent = .1M,});
            parts.Add(new Part {PartName = "Flexible whisker sensors", UnitPrice = 79, UpfrontPercent = 0M,});
            parts.Add(new Part {PartName = "Rotating Joint Assembly", UnitPrice = 289M, UpfrontPercent = .1M,});
            parts.Add(new Part {PartName = "Rotating Mobility Base Coupling", UnitPrice = 499M, UpfrontPercent = .1M,});
            parts.Add(new Part {PartName = "Flux Capacitor", UnitPrice = 1879M, UpfrontPercent = .25M,});
            parts.Add(new Part {PartName = "External Battery Packs", UnitPrice = 399M, UpfrontPercent = .1M,});
            parts.Add(new Part {PartName = "Articulated cutting wheel", UnitPrice = 275M, UpfrontPercent = .1M,});
            parts.Add(new Part {PartName = "Retractable Claw", UnitPrice = 349M, UpfrontPercent = .1M,});
            parts.Add(new Part {PartName = "Mountable Halogen Floodlights", UnitPrice = 100, UpfrontPercent = .1M,});
            parts.Add(new Part {PartName = "Universal Anchor Point", UnitPrice = 89, UpfrontPercent = 0M,});
            parts.Add(new Part {PartName = "Binocular Camera Array", UnitPrice = 389M, UpfrontPercent = .1M,});
            parts.Add(new Part {PartName = "Wire assortment", UnitPrice = 29, UpfrontPercent = 0M,});
            parts.Add(new Part {PartName = "Assorted Gears and Bearings", UnitPrice = 39, UpfrontPercent = 0M,});
            parts.Add(new Part {PartName = "Micro Servo Motor", UnitPrice = 69, UpfrontPercent = 0M});
            parts.Add(new Part {PartName = "High Torque Stepper Motor", UnitPrice = 189M, UpfrontPercent = .1M,});
            parts.Add(new Part {PartName = "Temperature Sensor", UnitPrice = 45, UpfrontPercent = 0M});
            parts.Add(new Part {PartName = "Sealed Gyro Module", UnitPrice = 618M, UpfrontPercent = .1M,});
            parts.Add(new Part {PartName = "Wireless Ethernet Adapter", UnitPrice = 55, UpfrontPercent = 0M});
            parts.Add(new Part {PartName = "GPS Receiver", UnitPrice = 105, UpfrontPercent = 0M});

            return parts;
        }
    }
}
