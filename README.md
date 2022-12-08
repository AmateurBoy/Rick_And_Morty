# Rick and Morty 
.NET client for Rick And Morty knowledge base api: https://rickandmortyapi.com/
![This is an image](https://rickandmortyapi.com/api/character/avatar/487.jpeg)

������� � �������� �������� ��� Rick and Morty API.
� ������� ����������� 2 ������.

```C#
RequestHandlerAPI RequestAPI = new();
	string personName = "Rick Sanchez";
	string episodeName = "Pilot";
	//response: StatusCode OK,NameNotCorrect,Error
	RequestAPI.Is�haracterInTheEpisode(personName, episodeName);
	//response: true;
```

```C#
	RequestHandlerAPI RequestAPI = new();
	CharacterDTO? characterDTO = await requestAPI.GiveDTObyName("Rick Sanchez");
```
/* response: 
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
*/

�������� ��������� ������ �������� :)
[Carlj28/RickAndMorty.Net.Api](https://github.com/Carlj28/RickAndMorty.Net.Api)


