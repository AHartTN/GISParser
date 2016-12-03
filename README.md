# GISParser

Finally got my parser finished for the raw data dump of the US Census Bureau's MAF/Tiger GIS dataset from ESRI shapefiles to Microsoft SQL Server.

Is it perfect? No... Far from it...

Does it work? ABSOLUTELY! It's rather hypnotizing to watch it work... There are a few OCD issues I have with it but aside from that, it functions as expected for dumping the raw data to SQL Server.

How do I use it?
Download the 2016 MAF/TIGER GIS dataset from the US Census Bureau. Keep the folder/file structures the same and DO NOT extract any of the files. This application will extract it for you. Once you've downloaded the dataset to a directory, update the App.config file's source directory to the directory you put the downloaded folders/files into. Also adjust the working directory as I was lazy and decided to extract each file one by one. This can be the same hard disk but performance will drastically improve if you use separate hard disks. Last thing to adjust is the connection string in the App.config. Once those things are done, run the application and it will create the database, tables, etc and will start importing the data for you.

What does it not do?
Indexes, foreign keys, associations, etc...

What comes after this?
Next steps are for me to write SQL queries that will manipulate the data even further into a referentially integral database with indexes, foreign keys and proper associations. Proper associations being that you'll be able to query a specific State/County/City/Zip and return ONLY what is contained within those boundaries instead of each piece being separated on it's own. IE: A zip code can extend between two cities and you only want the zip code for one specific city.
