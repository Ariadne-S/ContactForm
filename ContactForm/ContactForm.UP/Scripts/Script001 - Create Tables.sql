CREATE TABLE Contact (
	ContactId UniqueIdentifier PRIMARY KEY NONCLUSTERED NOT NULL,
	SequentialId Int identity NOT NULL,
	ContactName nVarChar(100) NOT NULL,
	Email nVarChar(100) NOT NULL,
	Comment nVarChar(1000) NOT NULL,
	SubmittedAt datetime2 NOT NULL
)