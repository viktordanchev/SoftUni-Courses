namespace Boardgames.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using System.Text.Json;
    using System.Xml.Serialization;
    using Boardgames.Data;
    using Boardgames.Data.Models;
    using Boardgames.Data.Models.Enums;
    using Boardgames.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCreator
            = "Successfully imported creator – {0} {1} with {2} boardgames.";

        private const string SuccessfullyImportedSeller
            = "Successfully imported seller - {0} with {1} boardgames.";

        public static string ImportCreators(BoardgamesContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(CreatorDto[]), new XmlRootAttribute("Creators"));
            var creatorDtos = (CreatorDto[])xmlSerializer.Deserialize(new StringReader(xmlString));
            var result = new StringBuilder();

            foreach (var creatorDto in creatorDtos)
            {
                if (!IsValid(creatorDto))
                {
                    result.AppendLine(ErrorMessage);
                }
                else
                {
                    var validCreator = new Creator()
                    {
                        FirstName = creatorDto.FirstName,
                        LastName = creatorDto.LastName
                    };

                    foreach (var boardgameDto in creatorDto.Boardgames)
                    {
                        if (!IsValid(boardgameDto))
                        {
                            result.AppendLine(ErrorMessage);
                        }
                        else
                        {
                            var validBoardgame = new Boardgame()
                            {
                                Name = boardgameDto.Name,
                                Rating = boardgameDto.Rating,
                                YearPublished = boardgameDto.YearPublished,
                                CategoryType = (CategoryType)boardgameDto.CategoryType,
                                Mechanics = boardgameDto.Mechanics
                            };

                            validCreator.Boardgames.Add(validBoardgame);

                            context.Boardgames.Add(validBoardgame);
                        }
                    }

                    context.Creators.Add(validCreator);

                    result.AppendLine(string.Format(SuccessfullyImportedCreator, 
                        validCreator.FirstName, 
                        validCreator.LastName,
                        validCreator.Boardgames.Count));
                }
            }

            context.SaveChanges();
            return result.ToString().Trim();
        }

        public static string ImportSellers(BoardgamesContext context, string jsonString)
        {
            var sellers = JsonSerializer.Deserialize<SellerDto[]>(jsonString);
            var boardgameIds = context.Boardgames.Select(x => x.Id).ToArray();
            var result = new StringBuilder();

            foreach (var seller in sellers)
            {
                if (!IsValid(seller))
                {
                    result.AppendLine(ErrorMessage);
                }
                else
                {
                    var validSeller = new Seller()
                    {
                        Name = seller.Name,
                        Address = seller.Address,
                        Country = seller.Country,
                        Website = seller.Website
                    };

                    foreach (var boardgameId in seller.Boardgames)
                    {
                        if (!IsValid(boardgameId) 
                            || !boardgameIds.Contains(boardgameId) 
                            || validSeller.BoardgamesSellers.Any(bs => bs.BoardgameId == boardgameId))
                        {
                            result.AppendLine(ErrorMessage);
                        }
                        else
                        {
                            var boardgameSeller = new BoardgameSeller()
                            {
                                BoardgameId = boardgameId,
                                Seller = validSeller
                            };

                            context.BoardgamesSellers.Add(boardgameSeller);
                        }
                    }

                    context.Sellers.Add(validSeller);

                    result.AppendLine(string.Format(SuccessfullyImportedSeller,
                        validSeller.Name,
                        validSeller.BoardgamesSellers.Count));
                }
            }

            context.SaveChanges();

            return result.ToString().Trim();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
