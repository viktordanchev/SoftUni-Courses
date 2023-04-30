using Formula1.Core.Contracts;
using Formula1.Models;
using Formula1.Models.Contracts;
using Formula1.Repositories;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Core
{
    public class Controller : IController
    {
        private PilotRepository pilotRepository;
        private RaceRepository raceRepository;
        private FormulaOneCarRepository formulaOneCarRepository;
        private List<string> validCarTypes = new List<string>() { "Ferrari", "Williams" };

        public Controller()
        {
            pilotRepository = new PilotRepository();
            raceRepository = new RaceRepository();
            formulaOneCarRepository = new FormulaOneCarRepository();
        }

        public string AddCarToPilot(string pilotName, string carModel)
        {
            IPilot pilot = pilotRepository.FindByName(pilotName);
            IFormulaOneCar car = formulaOneCarRepository.FindByName(carModel);

            if (pilot == null || pilot.Car != null)
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));

            if (car == null)
                throw new NullReferenceException(string.Format(ExceptionMessages.CarDoesNotExistErrorMessage, carModel));

            pilot.AddCar(car);
            formulaOneCarRepository.Remove(car);
            return string.Format(OutputMessages.SuccessfullyPilotToCar, pilotName, car.GetType().Name, carModel);
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            IRace race = raceRepository.FindByName(raceName);
            IPilot pilot = pilotRepository.FindByName(pilotFullName);

            if (race == null)
                throw new NullReferenceException(string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));

            if (pilot == null || pilot.CanRace == false || race.Pilots.Any(p => p.FullName == pilotFullName))
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));

            race.AddPilot(pilot);
            return string.Format(OutputMessages.SuccessfullyAddPilotToRace, pilotFullName, raceName);
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            IFormulaOneCar car = formulaOneCarRepository.FindByName(model);

            if (car != null)
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarExistErrorMessage, model));

            if (!validCarTypes.Any(t => t == type))
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidTypeCar, type));

            switch (type)
            {
                case "Ferrari":
                    car = new Ferrari(model, horsepower, engineDisplacement);
                    break;
                case "Williams":
                    car = new Williams(model, horsepower, engineDisplacement);
                    break;
            }

            formulaOneCarRepository.Add(car);
            return string.Format(OutputMessages.SuccessfullyCreateCar, type, model);
        }

        public string CreatePilot(string fullName)
        {
            IPilot pilot = pilotRepository.FindByName(fullName);

            if (pilot != null)
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotExistErrorMessage, fullName));

            pilot = new Pilot(fullName);

            pilotRepository.Add(pilot);
            return string.Format(OutputMessages.SuccessfullyCreatePilot, fullName);
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            IRace race = raceRepository.FindByName(raceName);

            if (race != null)
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExistErrorMessage, raceName));

            race = new Race(raceName, numberOfLaps);

            raceRepository.Add(race);
            return string.Format(OutputMessages.SuccessfullyCreateRace, raceName);
        }

        public string PilotReport()
        {
            List<IPilot> orderedPilots = pilotRepository.Models
                .OrderByDescending(p => p.NumberOfWins)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var pilot in orderedPilots)
            {
                sb.AppendLine(pilot.ToString());
            }

            return sb.ToString().Trim();
        }

        public string RaceReport()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var race in raceRepository.Models)
            {
                if (!race.TookPlace)
                    continue;

                sb.AppendLine(race.RaceInfo());
            }

            return sb.ToString().Trim();
        }

        public string StartRace(string raceName)
        {
            IRace race = raceRepository.FindByName(raceName);

            if (race == null)
                throw new NullReferenceException(string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));

            if (race.Pilots.Count < 3)
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRaceParticipants, raceName));

            if (race.TookPlace)
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceTookPlaceErrorMessage, raceName));

            List<IPilot> pilots = race.Pilots
                .OrderByDescending(p => p.Car.RaceScoreCalculator(race.NumberOfLaps))
                .ToList();

            pilots[0].WinRace();

            race.TookPlace = true;

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format(OutputMessages.PilotFirstPlace, pilots[0].FullName, raceName));
            sb.AppendLine(string.Format(OutputMessages.PilotSecondPlace, pilots[1].FullName, raceName));
            sb.AppendLine(string.Format(OutputMessages.PilotThirdPlace, pilots[2].FullName, raceName));

            return sb.ToString().Trim();
        }
    }
}
