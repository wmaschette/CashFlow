-- Creation of product table
CREATE TABLE IF NOT EXISTS DailyEntry (
  CreatedAt TIMESTAMP  NOT NULL,
  Amount DECIMAL(10,2) NOT NULL,
  OperationTypeId INT NOT NULL,
  Id UUID NOT NULL PRIMARY KEY
);