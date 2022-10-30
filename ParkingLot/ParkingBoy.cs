﻿using System;
using System.Collections.Generic;

namespace ParkingLotService
{
    public class ParkingBoy
    {
        public string ParkingBoyId { get; set; }

        public ParkingBoy(string parkingBoyId)
        {
            ParkingBoyId = parkingBoyId;
        }

        public List<string> UsedTicketList { get; set; } = new List<string>();

        public string ParkCar(Car car, ParkingLot parkingLot, ParkingBoy parkingBoy)
        {
            if (parkingLot.ParkingCars.Count < parkingLot.Capacity)
            {
                parkingLot.ParkingCars.Add(car.Plate);
                string ticketInfo = car.Plate + "; " + parkingLot.ParkingLotId + "; " + parkingBoy.ParkingBoyId;
                return ticketInfo;
            }
            else
            {
                return "No vacancy.";
            }
        }

        public string FetchCar(Ticket ticket)
        {
            if (ticket == null)
            {
                return null;
            }
            else
            {
                var ticketInfoRef = "JA88888; Parking Lot 01; Parking Boy 01";
                var ticketInfo = ticket.Plate + "; " + ticket.ParkingLoteNumber + "; " + ticket.ParkingBoyNumber;
                if (ticketInfo.Length != ticketInfoRef.Length)
                {
                    return "Wrong ticket.";
                }
                else
                {
                    if (UsedTicketList.Contains(ticket.TicketId))
                    {
                        return "Ticket has been used.";
                    }
                    else
                    {
                        UsedTicketList.Add(ticket.TicketId);
                        string plate = ticketInfo.Substring(0, 7);
                        return plate;
                    }
                }
            }
        }

        public List<string> ParkCars(List<Car> cars, ParkingLot parkingLot, ParkingBoy parkingBoy)
        {
            var tickets = new List<string>();
            foreach (var car in cars)
            {
                parkingLot.ParkingCars.Add(car.Plate);
                string ticket = car.Plate + "; " + parkingLot.ParkingLotId + "; " + parkingBoy.ParkingBoyId;
                tickets.Add(ticket);
            }

            return tickets;
        }

        public List<string> FetchCars(List<Ticket> tickets)
        {
            var plates = new List<string>();
            foreach (var ticket in tickets)
            {
                var ticketInfo = ticket.Plate + "; " + ticket.ParkingLoteNumber + "; " + ticket.ParkingBoyNumber;
                string plate = ticketInfo.Substring(0, 7);
                plates.Add(plate);
            }

            return plates;
        }
    }
}