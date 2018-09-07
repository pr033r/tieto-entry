## Tieto entry app

Application has two read/write classes available through *StorageFactory*:

* through XML file - *XML2DObjectsManager*
* MS SQL database - *DB2DObjectManager*

The \*.xml files and logs are stored in users's **AppData/Roaming/tieto-netry/** folder.

Test data are in **/data/testLoad.xml** file.

Database entities structure:

**Edge table:**

Column name | Data type | Allow nulls
 --- | --- | ---
 PK id | int | false
 edge | float | false
 FK objectId | int | false

**Object table:**

Column name | Data type | Allow nulls
 --- | --- | ---
 PK id | int | false
 periphery | float | true