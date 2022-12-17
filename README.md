# Rick and Morty 
.NET client for Rick And Morty knowledge base api: https://rickandmortyapi.com/
![This is an image](https://upload.wikimedia.org/wikipedia/ru/thumb/c/c8/Rick_and_Morty_logo.png/640px-Rick_and_Morty_logo.png)

A simple and stripped down wrapper for the Rick and Morty API. 
Which contains 2 methods.

The main logic is in the RequestService class in which API requests are made, 
after which we process and cache them in the RickAndMortyCachedService class. 
And we give the result in the controller(CustomRickAndMortyController) that send the response.

---
Methods Wrapper methods over pure requests.


```cs
IRickAndMortyCachedService service = new RickAndMortyCachedService();
string personName = "Rick Sanchez";
string episodeName = "Pilot";
await service.IsValidationDataAsync(personName, episodeName);
//response: true or false or Exception("NotFound");
```

---
```cs
IRickAndMortyCachedService service = new RickAndMortyCachedService();
CharacterDTO? characterDTO = await service.GetCharacterbyNameAsync("Rick Sanchez");
/* 
response: 
    {   
        "name": "Rick Sanchez",
        "status": "Alive",
        "species": "Human",
        "type": "",
        "gender": "Male",
        "origin": {
            "name": "Earth (C-137)",
            "type": "Planet",
            "dimension": "Dimension C-137"
        }
    }
    or
    Exeption("NotFound")
*/
```

---
Methods working a request.

---
```cs
    
        IRequetService service = new RequestRickAndMortyAPIService(); or DI builder.Services.AddTransient<IRequestService, RequestRickAndMortyAPIService>();
        //Get Character by id.
        Task<FullCharacter> GetCharacterByIDAsync(int id);
        //Get characters by array id.
        Task<IEnumerable<FullCharacter>> GetCharacterMultipleAsync(int[] ids);
        //Get characters by name.
        Task<IEnumerable<Character>> GetCharacterByNameAsync(string name);        
        //Get episode by name.
        Task<IEnumerable<Episode>> GetEpisodeByNameAsync(string name);
        //Get Location by id.
        Task<FullLocation> GetLocationByIdAsync(int id);
```





