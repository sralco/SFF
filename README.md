# Sveriges Förenade Filmföreningar


|Endpoint -url/api/v1    |Metod |Beskrivning                      |Req Body             |Res Body             |
|------------------------|------|---------------------------------|---------------------|---------------------|
|/association            |POST  |Lägger till ny förening          |Ett associationobjekt|Ett associationobjekt|
|/association/{id}       |DELETE|Tar bort förening                |Ingen                |Ingen                |
|/association/{id}/update|PUT   |Uppdaterar förening              |Ett associationobjekt|Ingen                |
|/association/{id}/movies|GET   |Hämtar en förenings lånade filmer|Ingen                |Lista med movieobjekt|
|/association/{id}       |GET   |Hämtar en förening               |Ingen                |Ett associationobjekt|
|/lending                |POST  |Lägger till ett lån              |Ingen                |Ett lendingobjekt    |
|/lending/{id}/return    |PATCH |Markerar lån som återlämnat      |Ingen                |Ingen                |
|/lending/{id}           |GET   |Hämtar ett lån                   |Ingen                |Ett lendingobjekt    |
|/movies                 |POST  |Lägger till ny film              |Ett movieobjekt      |Ett movieobjekt      |
|/movie/{id}/licenses    |PATCH |Uppdaterar antalet licenser      |Ingen                |Ingen                |
|/movie/{id}/update      |PUT   |Uppdaterar en film               |Ett movieobjekt      |Ingen                |
|/movie                  |GET   |Hämtar alla filmer               |Ingen                |Lista med movieobjekt|
|/movie/{id}             |GET   |Hämtar en film                   |Ingen                |Ett movieobjekt      |
|/review                 |POST  |Lägger till en recension         |Ett reviewobjekt     |Ett reviewobjekt     |
|/review/{id}            |GET   |Hämtar en recension              |Ingen                |Ett reviewobjekt     |