﻿using EddiCore;
using EddiDataDefinitions;
using EddiStatusMonitor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Utilities;

namespace UnitTests
{
    [TestClass]
    public class StatusMonitorTests : TestBase
    {
        [TestInitialize]
        public void start()
        {
            MakeSafe();
        }

        [TestMethod]
        public void TestParseStatusFlagsDocked()
        {
            string line = "{ \"timestamp\":\"2018-03-25T00:39:48Z\", \"event\":\"Status\", \"Flags\":16842765, \"Pips\":[5,2,5], \"FireGroup\":0, \"GuiFocus\":0 }";
            Status status = ((StatusMonitor)EDDI.Instance.ObtainMonitor("Status monitor")).ParseStatusEntry(line);

            // Variables set from status flags (when not signed in, flags are set to '0')
            DateTime expectedTimestamp = new DateTime(2018, 3, 25, 0, 39, 48, DateTimeKind.Utc);
            Assert.AreEqual(expectedTimestamp, status.timestamp);
            Assert.AreEqual(status.flags, (Status.Flags)16842765);
            Assert.AreEqual(status.vehicle, "Ship");
            Assert.IsFalse(status.being_interdicted);
            Assert.IsFalse(status.in_danger);
            Assert.IsFalse(status.near_surface);
            Assert.IsFalse(status.overheating);
            Assert.IsFalse(status.low_fuel);
            Assert.AreEqual(status.fsd_status, "masslock");
            Assert.IsFalse(status.srv_drive_assist);
            Assert.IsFalse(status.srv_under_ship);
            Assert.IsFalse(status.srv_turret_deployed);
            Assert.IsFalse(status.srv_handbrake_activated);
            Assert.IsFalse(status.scooping_fuel);
            Assert.IsFalse(status.silent_running);
            Assert.IsFalse(status.cargo_scoop_deployed);
            Assert.IsFalse(status.lights_on);
            Assert.IsFalse(status.in_wing);
            Assert.IsFalse(status.hardpoints_deployed);
            Assert.IsFalse(status.flight_assist_off);
            Assert.IsFalse(status.supercruise);
            Assert.IsTrue(status.shields_up);
            Assert.IsTrue(status.landing_gear_down);
            Assert.IsFalse(status.landed);
            Assert.IsTrue(status.docked);
        }

        [TestMethod]
        public void TestParseStatusFlagsDockedOdyssey()
        {
            string line = "{ \"timestamp\":\"2021-05-01T21:04:13Z\", \"event\":\"Status\", \"Flags\":151060493, \"Flags2\":0, \"Pips\":[4,8,0], \"FireGroup\":0, \"GuiFocus\":0, \"Fuel\":{ \"FuelMain\":32.000000, \"FuelReservoir\":0.630000 }, \"Cargo\":0.000000, \"LegalState\":\"Clean\" }";
            Status status = ((StatusMonitor)EDDI.Instance.ObtainMonitor("Status monitor")).ParseStatusEntry(line);

            // Variables set from status flags (when not signed in, flags are set to '0')
            DateTime expectedTimestamp = new DateTime(2021, 5, 1, 21, 4, 13, DateTimeKind.Utc);
            Assert.AreEqual(expectedTimestamp, status.timestamp);
            Assert.AreEqual((Status.Flags)151060493, status.flags);
            Assert.AreEqual((Status.Flags2)0, status.flags2);
            Assert.AreEqual(Constants.VEHICLE_SHIP, status.vehicle);
            Assert.IsFalse(status.being_interdicted);
            Assert.IsFalse(status.in_danger);
            Assert.IsFalse(status.near_surface);
            Assert.IsFalse(status.overheating);
            Assert.IsFalse(status.low_fuel);
            Assert.AreEqual("masslock", status.fsd_status);
            Assert.IsFalse(status.srv_drive_assist);
            Assert.IsFalse(status.srv_under_ship);
            Assert.IsFalse(status.srv_turret_deployed);
            Assert.IsFalse(status.srv_handbrake_activated);
            Assert.IsFalse(status.srv_high_beams);
            Assert.IsFalse(status.scooping_fuel);
            Assert.IsFalse(status.silent_running);
            Assert.IsFalse(status.cargo_scoop_deployed);
            Assert.IsFalse(status.lights_on);
            Assert.IsFalse(status.in_wing);
            Assert.IsFalse(status.hardpoints_deployed);
            Assert.IsFalse(status.flight_assist_off);
            Assert.IsFalse(status.supercruise);
            Assert.IsFalse(status.hyperspace);
            Assert.IsTrue(status.shields_up);
            Assert.IsTrue(status.landing_gear_down);
            Assert.IsFalse(status.landed);
            Assert.IsTrue(status.docked);
            Assert.IsTrue(status.analysis_mode);
            Assert.IsFalse(status.night_vision);
            Assert.IsFalse(status.altitude_from_average_radius);
            Assert.IsFalse(status.on_foot_in_station);
            Assert.IsFalse(status.on_foot_on_planet);
            Assert.IsFalse(status.aim_down_sight);
            Assert.IsFalse(status.low_oxygen);
            Assert.IsFalse(status.low_health);
            Assert.AreEqual("temperate", status.on_foot_temperature);
            Assert.IsFalse(status.hardpoints_deployed);
            Assert.AreEqual(2M, status.pips_sys);
            Assert.AreEqual(4M, status.pips_eng);
            Assert.AreEqual(0M, status.pips_wea);
            Assert.AreEqual(0, status.firegroup);
            Assert.AreEqual("none", status.gui_focus);
            Assert.AreEqual(32M, status.fuelInTanks);
            Assert.AreEqual(0.63M, status.fuelInReservoir);
            Assert.AreEqual(0, status.cargo_carried);
            Assert.AreEqual("Clean", status.legalstatus);
            Assert.IsFalse(status.aim_down_sight);
            Assert.AreEqual(null, status.altitude);
        }

        [TestMethod]
        public void TestParseStatusFlagsDockedDropshipOdyssey()
        {
            string line = "{ \"timestamp\":\"2021-05-01T23:10:06Z\", \"event\":\"Status\", \"Flags\":16842761, \"Flags2\":2, \"Pips\":[4,4,4], \"FireGroup\":0, \"GuiFocus\":0, \"Fuel\":{ \"FuelMain\":8.000000, \"FuelReservoir\":0.570000 }, \"Cargo\":0.000000, \"LegalState\":\"Clean\" }";
            Status status = ((StatusMonitor)EDDI.Instance.ObtainMonitor("Status monitor")).ParseStatusEntry(line);

            // Variables set from status flags (when not signed in, flags are set to '0')
            DateTime expectedTimestamp = new DateTime(2021, 5, 1, 23, 10, 06, DateTimeKind.Utc);
            Assert.AreEqual(expectedTimestamp, status.timestamp);
            Assert.AreEqual((Status.Flags)16842761, status.flags);
            Assert.AreEqual((Status.Flags2)2, status.flags2);
            Assert.AreEqual(Constants.VEHICLE_TAXI, status.vehicle);
            Assert.IsFalse(status.being_interdicted);
            Assert.IsFalse(status.in_danger);
            Assert.IsFalse(status.near_surface);
            Assert.IsFalse(status.overheating);
            Assert.IsFalse(status.low_fuel);
            Assert.AreEqual("masslock", status.fsd_status);
            Assert.IsFalse(status.srv_drive_assist);
            Assert.IsFalse(status.srv_under_ship);
            Assert.IsFalse(status.srv_turret_deployed);
            Assert.IsFalse(status.srv_handbrake_activated);
            Assert.IsFalse(status.srv_high_beams);
            Assert.IsFalse(status.scooping_fuel);
            Assert.IsFalse(status.silent_running);
            Assert.IsFalse(status.cargo_scoop_deployed);
            Assert.IsFalse(status.lights_on);
            Assert.IsFalse(status.in_wing);
            Assert.IsFalse(status.hardpoints_deployed);
            Assert.IsFalse(status.flight_assist_off);
            Assert.IsFalse(status.supercruise);
            Assert.IsFalse(status.hyperspace);
            Assert.IsTrue(status.shields_up);
            Assert.IsFalse(status.landing_gear_down);
            Assert.IsFalse(status.landed);
            Assert.IsTrue(status.docked);
            Assert.IsFalse(status.analysis_mode);
            Assert.IsFalse(status.night_vision);
            Assert.IsFalse(status.altitude_from_average_radius);
            Assert.IsFalse(status.on_foot_in_station);
            Assert.IsFalse(status.on_foot_on_planet);
            Assert.IsFalse(status.aim_down_sight);
            Assert.IsFalse(status.low_oxygen);
            Assert.IsFalse(status.low_health);
            Assert.AreEqual("temperate", status.on_foot_temperature);
            Assert.IsFalse(status.hardpoints_deployed);
            Assert.AreEqual(2M, status.pips_sys);
            Assert.AreEqual(2M, status.pips_eng);
            Assert.AreEqual(2M, status.pips_wea);
            Assert.AreEqual(0, status.firegroup);
            Assert.AreEqual("none", status.gui_focus);
            Assert.AreEqual(8M, status.fuelInTanks);
            Assert.AreEqual(0.57M, status.fuelInReservoir);
            Assert.AreEqual(0, status.cargo_carried);
            Assert.AreEqual("Clean", status.legalstatus);
            Assert.IsFalse(status.aim_down_sight);
            Assert.AreEqual(null, status.altitude);
        }

        [TestMethod]
        public void TestParseStatusFlagsNormalSpace()
        {
            string line = "{ \"timestamp\":\"2018-03-25T00:39:48Z\", \"event\":\"Status\", \"Flags\":16777320, \"Pips\":[7,1,4], \"FireGroup\":0, \"GuiFocus\":0 }";
            Status status = ((StatusMonitor)EDDI.Instance.ObtainMonitor("Status monitor")).ParseStatusEntry(line);

            // Variables set from status flags (when not signed in, flags are set to '0')
            Assert.AreEqual(status.flags, (Status.Flags)16777320);
            Assert.AreEqual(status.vehicle, "Ship");
            Assert.IsFalse(status.being_interdicted);
            Assert.IsFalse(status.in_danger);
            Assert.IsFalse(status.near_surface);
            Assert.IsFalse(status.overheating);
            Assert.IsFalse(status.low_fuel);
            Assert.AreEqual(status.fsd_status, "ready");
            Assert.IsFalse(status.srv_drive_assist);
            Assert.IsFalse(status.srv_under_ship);
            Assert.IsFalse(status.srv_turret_deployed);
            Assert.IsFalse(status.srv_handbrake_activated);
            Assert.IsFalse(status.scooping_fuel);
            Assert.IsFalse(status.silent_running);
            Assert.IsFalse(status.cargo_scoop_deployed);
            Assert.IsFalse(status.lights_on);
            Assert.IsFalse(status.in_wing);
            Assert.IsTrue(status.hardpoints_deployed);
            Assert.IsTrue(status.flight_assist_off);
            Assert.IsFalse(status.supercruise);
            Assert.IsTrue(status.shields_up);
            Assert.IsFalse(status.landing_gear_down);
            Assert.IsFalse(status.landed);
            Assert.IsFalse(status.docked);
        }

        [TestMethod]
        public void TestParseStatusFlagsSrv()
        {
            string line = "{ \"timestamp\":\"2018-03-25T00:39:48Z\", \"event\":\"Status\", \"Flags\":69255432, \"Pips\":[2,8,2], \"FireGroup\":0, \"GuiFocus\":0, \"Latitude\":-5.683115, \"Longitude\":-10.957623, \"Heading\":249, \"Altitude\":0, \"BodyName\":\"Myeia Thaa QI - B d13 - 1 1\", \"PlanetRadius\":2140275.000000}";
            Status status = ((StatusMonitor)EDDI.Instance.ObtainMonitor("Status monitor")).ParseStatusEntry(line);

            // Variables set from status flags (when not signed in, flags are set to '0')
            Assert.AreEqual(status.flags, (Status.Flags)69255432);
            Assert.AreEqual(status.vehicle, "SRV");
            Assert.IsFalse(status.being_interdicted);
            Assert.IsFalse(status.in_danger);
            Assert.IsTrue(status.near_surface);
            Assert.IsFalse(status.overheating);
            Assert.IsFalse(status.low_fuel);
            Assert.AreEqual(status.fsd_status, "ready");
            Assert.IsTrue(status.srv_drive_assist);
            Assert.IsTrue(status.srv_under_ship);
            Assert.IsFalse(status.srv_turret_deployed);
            Assert.IsFalse(status.srv_handbrake_activated);
            Assert.IsFalse(status.scooping_fuel);
            Assert.IsFalse(status.silent_running);
            Assert.IsFalse(status.cargo_scoop_deployed);
            Assert.IsTrue(status.lights_on);
            Assert.IsFalse(status.in_wing);
            Assert.IsFalse(status.hardpoints_deployed);
            Assert.IsFalse(status.flight_assist_off);
            Assert.IsFalse(status.supercruise);
            Assert.IsTrue(status.shields_up);
            Assert.IsFalse(status.landing_gear_down);
            Assert.IsFalse(status.landed);
            Assert.IsFalse(status.docked);
            Assert.AreEqual("Myeia Thaa QI - B d13 - 1 1", status.bodyname);
            Assert.AreEqual(2140275.000000M, status.planetradius);
        }

        [TestMethod]
        public void TestParseStatusFlagsSupercruise()
        {
            string line = "{ \"timestamp\":\"2018-03-25T00:39:48Z\", \"event\":\"Status\", \"Flags\":16777240, \"Pips\":[7,1,4], \"FireGroup\":0, \"GuiFocus\":0, \"Fuel\":{ \"FuelMain\":26.589718, \"FuelReservoir\":0.484983 }, \"Cargo\":3.000000, \"LegalState\":\"Clean\" }";
            Status status = ((StatusMonitor)EDDI.Instance.ObtainMonitor("Status monitor")).ParseStatusEntry(line);

            // Variables set from status flags (when not signed in, flags are set to '0')
            Assert.AreEqual((Status.Flags)16777240, status.flags);
            Assert.AreEqual("Ship", status.vehicle);
            Assert.AreEqual(26.589718M, status.fuelInTanks);
            Assert.AreEqual(0.484983M, status.fuelInReservoir);
            Assert.AreEqual(26.589718M + 0.484983M, status.fuel);
            Assert.AreEqual(3, status.cargo_carried);
            Assert.AreEqual(LegalStatus.Clean, status.legalStatus);
            Assert.IsTrue(status.supercruise);
        }

        [TestMethod]
        public void TestParseStatusPips()
        {
            string line = "{ \"timestamp\":\"2018-03-25T00:39:48Z\", \"event\":\"Status\", \"Flags\":16842765, \"Pips\":[5,2,5], \"FireGroup\":0, \"GuiFocus\":0 }";
            Status status = ((StatusMonitor)EDDI.Instance.ObtainMonitor("Status monitor")).ParseStatusEntry(line);

            Assert.AreEqual(2.5M, status.pips_sys);
            Assert.AreEqual(1M, status.pips_eng);
            Assert.AreEqual(2.5M, status.pips_wea);
        }

        [TestMethod]
        public void TestParseStatusFiregroup()
        {
            string line = "{ \"timestamp\":\"2018-03-25T00:39:48Z\", \"event\":\"Status\", \"Flags\":16842765, \"Pips\":[5,2,5], \"FireGroup\":1, \"GuiFocus\":0 }";
            Status status = ((StatusMonitor)EDDI.Instance.ObtainMonitor("Status monitor")).ParseStatusEntry(line);

            Assert.AreEqual(1, status.firegroup);
        }

        [TestMethod]
        public void TestParseStatusGuiFocus()
        {
            string line = "{ \"timestamp\":\"2018-03-25T00:39:48Z\", \"event\":\"Status\", \"Flags\":16842765, \"Pips\":[5,2,5], \"FireGroup\":1, \"GuiFocus\":5 }";
            Status status = ((StatusMonitor)EDDI.Instance.ObtainMonitor("Status monitor")).ParseStatusEntry(line);

            Assert.AreEqual("station services", status.gui_focus);
        }

        [TestMethod]
        public void TestParseStatusGps1()
        {
            string line = "{ \"timestamp\":\"2018-03-25T00:39:48Z\", \"event\":\"Status\", \"Flags\":16842765, \"Pips\":[5,2,5], \"FireGroup\":1, \"GuiFocus\":0 }";
            Status status = ((StatusMonitor)EDDI.Instance.ObtainMonitor("Status monitor")).ParseStatusEntry(line);

            Assert.IsNull(status.latitude);
            Assert.IsNull(status.longitude);
            Assert.IsNull(status.altitude);
            Assert.IsNull(status.heading);
        }

        [TestMethod]
        public void TestParseStatusGps2()
        {
            string line = "{ \"timestamp\":\"2018-03-25T00:39:48Z\", \"event\":\"Status\", \"Flags\":69255432, \"Pips\":[2,8,2], \"FireGroup\":0, \"GuiFocus\":0, \"Latitude\":-5.683115, \"Longitude\":-10.957623, \"Heading\":249, \"Altitude\":0}";
            Status status = ((StatusMonitor)EDDI.Instance.ObtainMonitor("Status monitor")).ParseStatusEntry(line);

            Assert.AreEqual(-5.683115M, status.latitude);
            Assert.AreEqual(-10.957623M, status.longitude);
            Assert.AreEqual(0M, status.altitude);
            Assert.AreEqual(249M, status.heading);
        }

        [TestMethod]
        public void TestParseStatusFlagsAnalysisFssMode()
        {
            string line = "{ \"timestamp\":\"2018 - 11 - 15T04: 41:06Z\", \"event\":\"Status\", \"Flags\":151519320, \"Pips\":[4,4,4], \"FireGroup\":2, \"GuiFocus\":9, \"Fuel\":{ \"FuelMain\":15.260000, \"FuelReservoir\":0.444812 }, \"Cargo\":39.000000 }";
            Status status = ((StatusMonitor)EDDI.Instance.ObtainMonitor("Status monitor")).ParseStatusEntry(line);

            Assert.AreEqual(true, status.analysis_mode);
            Assert.AreEqual("fss mode", status.gui_focus);
        }

        [TestMethod]
        public void TestParseStatusFlagsAnalysisSaaMode()
        {
            string line = "{ \"timestamp\":\"2018 - 11 - 15T04: 47:51Z\", \"event\":\"Status\", \"Flags\":150995032, \"Pips\":[4,4,4], \"FireGroup\":2, \"GuiFocus\":10, \"Fuel\":{ \"FuelMain\":15.260000, \"FuelReservoir\":0.444812 }, \"Cargo\":39.000000 }";
            Status status = ((StatusMonitor)EDDI.Instance.ObtainMonitor("Status monitor")).ParseStatusEntry(line);

            Assert.AreEqual(true, status.analysis_mode);
            Assert.AreEqual("saa mode", status.gui_focus);
        }

        [TestMethod]
        public void TestParseStatusFlagsNightMode()
        {
            string line = "{ \"timestamp\":\"2018 - 11 - 15T04: 58:37Z\", \"event\":\"Status\", \"Flags\":422117640, \"Pips\":[4,4,4], \"FireGroup\":2, \"GuiFocus\":0, \"Fuel\":{ \"FuelMain\":29.0, \"FuelReservoir\":0.564209 }, \"Cargo\":39.000000, \"Latitude\":88.365417, \"Longitude\":99.356514, \"Heading\":29, \"Altitude\":36 }";
            Status status = ((StatusMonitor)EDDI.Instance.ObtainMonitor("Status monitor")).ParseStatusEntry(line);

            Assert.AreEqual(true, status.night_vision);
            Assert.AreEqual(true, status.lights_on);
            Assert.AreEqual("none", status.gui_focus);
            Assert.AreEqual(29.564209M, status.fuel);
            Assert.AreEqual(39, status.cargo_carried);
        }
    }
}
