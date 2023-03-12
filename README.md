# EntityFramework

Api Calls as following

1. https://localhost:7087/api/Charactor  (POST)
{
   "name": "Legolas",
   "rpgclass" : "Archer",
   "userId":2
}

2. https://localhost:7087/api/Charactor?userId=2 (GET)

3. https://localhost:7087/api/Charactor/weapon (POST)

{
    "name" : "Magic Staff",
    "damage": 200,
    "characterId":4
}
4. https://localhost:7087/api/Charactor/skills (POST)

{
    "charactorId":3,
    "skillId": 1
}

