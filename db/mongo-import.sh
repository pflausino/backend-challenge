#! /bin/bash

mongoimport  --username=MyAdmin --password=MyAdminPassw0rd  --db=squere-meters-calculator --collection=city  --type=json --file=/mongo-seed/city.json --jsonArray

mongoimport  --username=MyAdmin --password=MyAdminPassw0rd  --db=squere-meters-calculator --collection=property  --type=json --file=/mongo-seed/property.json --jsonArray

