db.createUser({
    user: 'MyAdmin',
    pwd: 'MyAdminPassw0rd',
    roles: [
      {
        role: 'readWrite',
        db: 'squere-meters-calculator',
      },
    ],
  });

db = db.getSiblingDB("admin")
db.createUser({ user: "mongoadmin" , pwd: "mongoadmin", roles: ["userAdminAnyDatabase", "dbAdminAnyDatabase", "readWriteAnyDatabase"]})

