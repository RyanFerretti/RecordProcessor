# RecordProcessor

## Input
A record consists of the following 5 fields: last name, first name, gender, date of birth and favorite color. The input is 3 files, each containing records stored in a different format. You may generate these files yourself, and you can make certain assumptions if it makes solving your problem easier.
* The pipe-delimited file lists each record as follows: 
  * LastName | FirstName | Gender | FavoriteColor | DateOfBirth
* The comma-delimited file looks like this: 
  * LastName, FirstName, Gender, FavoriteColor, DateOfBirth
* The space-delimited file looks like this: 
  * LastName FirstName Gender FavoriteColor DateOfBirth
  
**Assumptions**
* All record data contained in the files contains valid data.  No fields are empty and dates are in the format M/D/YYYY.
* The project's base directory is C:\RecordProcessor
  * If you are not running under this directory you will need to update paths to the record files to get the Api working.
  * You can change the paths in the `Global.asax.cs` file.  Find the field `RecordPaths` and update to your current base path.
  
## Output
Create and display 3 different views of the data you read in:
* Output 1 – sorted by gender (females before males) then by last name ascending.
* Output 2 – sorted by birth date, ascending.
* Output 3 – sorted by last name, descending.
