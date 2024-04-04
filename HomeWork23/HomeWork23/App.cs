using HomeWork23.Dto.Requests;
using HomeWork23.Models;
using HomeWork23.Services.Abstracts;

namespace HomeWork23
{
    internal class App
    {
        private readonly IPetService _petService;
        private readonly ILocationService _locationService;
        private readonly ICategoryService _categoryService;
        private readonly IBreedService _breedService;

        public App(
            IPetService petService,
            ICategoryService categoryService,
            IBreedService breedService,
            ILocationService locationService)
        { 
            _petService = petService;
            _categoryService = categoryService;
            _breedService = breedService;
            _locationService = locationService;
        }
        public async Task Start()
        {
            var locationId = await _locationService.AddLocationAsync("Ukraine");
            var location = await _locationService.GetLocationAsync(locationId);

            var catId = await _categoryService.AddCategoryAsync("Cat");
            var dogId = await _categoryService.AddCategoryAsync("Dog");
            var pigId = await _categoryService.AddCategoryAsync("Pig");

            var cat = await _categoryService.GetCategoryAsync(catId);
            var dog = await _categoryService.GetCategoryAsync(dogId);
            var pig = await _categoryService.GetCategoryAsync(pigId);
            
            var pichId = await _breedService.AddBreedAsync(new Breed()
            {
                Name = "Pich",
                Category = cat,
            });

            var pyshokId = await _breedService.AddBreedAsync(new Breed()
            {
                Name = "Pyshok",
                Category = dog
            });

            var potId = await _breedService.AddBreedAsync(new Breed()
            {
                Name = "Pot",
                Category = cat,
            });

            var dotId = await _breedService.AddBreedAsync(new Breed()
            {
                Name = "Dot",
                Category = cat,
            });

            var vedId = await _breedService.AddBreedAsync(new Breed()
            {
                Name = "Ved",
                Category = dog,
            });

            var pigiId = await _breedService.AddBreedAsync(new Breed()
            {
                Name = "Pigi",
                Category = pig,
            });

            var pich = await _breedService.GetBreedAsync(pichId);
            var pyshok = await _breedService.GetBreedAsync(pyshokId);
            var pot = await _breedService.GetBreedAsync(potId);
            var dot = await _breedService.GetBreedAsync(dotId);
            var ved = await _breedService.GetBreedAsync(vedId);
            var pigi = await _breedService.GetBreedAsync(pigiId);

            var petIdPi = await _petService.AddPetAsync(new Pet()
            {
                Name = "Pi",
                Category = cat,
                CategoryId = cat.Id,
                Location = location,
                LocationId = location.Id,
                Breed = pich,
                BreedId = pich.Id,
                Age = 9
            });

            var pyshokIdPy = await _petService.AddPetAsync(new Pet()
            { 
                Name = "Py",
                Category = dog,
                CategoryId = dog.Id,
                Location = location,
                LocationId = location.Id,
                Breed = pyshok,
                BreedId = pyshok.Id,
                Age = 5
            });

            var potIdPo = await _petService.AddPetAsync(new Pet()
            { 
                Name = "Po",
                Category = cat,
                CategoryId = cat.Id,
                Location = location,
                LocationId = location.Id,
                Breed = pot,
                BreedId = pot.Id,
                Age = 6
            });

            var dotIdDo = await _petService.AddPetAsync(new Pet()
            {
                Name = "Do",
                Category = cat,
                CategoryId = cat.Id,
                Location = location,
                LocationId = location.Id,
                Breed = dot,
                BreedId = dot.Id,
                Age = 4
            }) ;

            var vedIdVe = await _petService.AddPetAsync(new Pet()
            {
                Name = "Ve",
                Category = dog,
                CategoryId = dog.Id,
                Location = location,
                LocationId = location.Id,
                Breed = ved,
                BreedId = ved.Id,
                Age = 4
            });

            var PigiIdpi = await _petService.AddPetAsync(new Pet()
            { 
                Name = "Pig",
                Category = pig,
                CategoryId = pig.Id,
                Location = location,
                LocationId = location.Id,
                Breed = pigi,
                BreedId = pigi.Id,
                Age = 7
            });

            var petPi = await _petService.GetPetAsync(petIdPi);
            var pyshokPy = await _petService.GetPetAsync(pyshokIdPy);

            var petRequest = new PetRequest()
            { 
                Age = 3,
                LocationCondition = "Ukraine"
            };

            var set = await _petService.GetPetPageAsync(petRequest);

            foreach (var item in set.FiltrData)
            {
                Console.WriteLine($"{item.Key} {item.Value}");
            }

            var errorId = await _petService.GetPetAsync(12131);
            
            var delete = await _petService.DeletePetAsync(petIdPi);

            Console.WriteLine(delete);

            pigi.Name = "Pigi2";
            pigi.Category = dog;
            pigi.CategoryId = dog.Id;

            var upDateBreed = await _breedService.UpdateBreedAsync(pigi);

            Console.WriteLine(upDateBreed.Name);
            Console.WriteLine(upDateBreed.Category.Name);
        }
    }
}
