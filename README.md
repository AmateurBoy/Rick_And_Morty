# Rick and Morty 
.NET client for Rick And Morty knowledge base api: https://rickandmortyapi.com/
![This is an image](https://rickandmortyapi.com/api/character/avatar/487.jpeg)

A simple and stripped down wrapper for the Rick and Morty API. 
Which contains 2 methods.

---
```cs
    Service service = new();
	string personName = "Rick Sanchez";
	string episodeName = "Pilot";
	await service.IsValidationDataAsync(personName, episodeName);
	//response: true or false or Exception("NotFound");
```

---
```cs
	Service service = new();
	CharacterDTO? characterDTO = await requestAPI.GetCharacterbyNameAsync("Rick Sanchez");
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

A shell inherits another shell :yum:
[Carlj28/RickAndMorty.Net.Api](https://github.com/Carlj28/RickAndMorty.Net.Api)


