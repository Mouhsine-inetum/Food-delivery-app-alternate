using FoodDeliveryClient.App.Models.Dto.Stores;
using FoodDeliveryClient.App.Models.Inputs.Stores;
using FoodDeliveryClient.App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FoodDeliveryClient.App.Pages.Stores
{
    public class CreateModel : PageModel
    {
        private List<CoordinateDto> Coordinates { get; set; } = new List<CoordinateDto>();
        public CreateStoreDto Store;
        private readonly Random _random = new Random(1);
        private readonly IStoreService _storeService;
        public CreateModel(IStoreService storeService)
        {
            _storeService = storeService;
            Store = new CreateStoreDto();
        }
        public void OnGet()
        {

        }



        private Task GenerateClosedPolygon()
        {
            int numberOfVertices = _random.Next(2,15);
            // Ensure at least 3 vertices to form a closed polygon
            if (numberOfVertices < 3)
            {
                throw new ArgumentException("A polygon must have at least 3 vertices.");
            }


            for (int i = 0; i < numberOfVertices; i++)
            {
                double xCoord = _random.NextDouble() * 100; // Adjust the range as needed
                double yCoord = _random.NextDouble() * 100; // Adjust the range as needed
                Coordinates.Add(new CoordinateDto()
                {
                    x= xCoord,
                    y= yCoord
                });
            }

            // Add the first vertex at the end to close the polygon
            Coordinates.Add(Coordinates[0]);

            return Task.CompletedTask;
        }


        private async Task<List<CoordinateDto>> GenerateRegularPolygon()
        {
            double radius = _random.NextDouble() * 100;
            int numberOfVertices = _random.Next(2, 15);
            // Ensure at least 3 vertices to form a closed polygon
            if (numberOfVertices < 3)
            {
                throw new ArgumentException("A polygon must have at least 3 vertices.");
            }

            List<CoordinateDto> polygonCoordinates = new List<CoordinateDto>();
            double angleIncrement = 2 * Math.PI / numberOfVertices;

            for (int i = 0; i < numberOfVertices; i++)
            {
                double angle = i * angleIncrement;
                double x = radius * Math.Cos(angle);
                double y = radius * Math.Sin(angle);

                polygonCoordinates.Add(new CoordinateDto()
                {
                    x=x,
                    y=y
                });
            }

            // Close the polygon
            polygonCoordinates.Add(polygonCoordinates[0]);

            return await Task.FromResult(polygonCoordinates);
            
        }

        public async Task OnPost(CreateStoreDto createStoreDto)
        {
            await GenerateClosedPolygon();
            createStoreDto.Coordinates = Coordinates;
            CreateStoreDto result= await _storeService.PostStoreAsync(createStoreDto);
        }
    }
}
