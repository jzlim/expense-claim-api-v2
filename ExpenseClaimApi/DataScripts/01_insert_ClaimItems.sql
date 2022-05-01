use expenseclaimdb
GO

insert into ClaimItems 
values
('4165', 'Staff Reimbursement Mobile Clair *Mobile phone charges', 0, GETDATE(), GETDATE()),
('4190', 'Postage', 0, GETDATE(), GETDATE()),
('4191', 'Couriers', 0, GETDATE(), GETDATE()),
('4200', 'Stationery', 0, GETDATE(), GETDATE()),
('4311', 'International Fares *Oversea Air-ticket', 0, GETDATE(), GETDATE()),
('4212', 'International Accomodation *Oversea hotel', 0, GETDATE(), GETDATE()),
('4313', 'International Expenses *Oversea Transports and Meals Expense', 0, GETDATE(), GETDATE()),
('4321', 'Local Fares *Taxi claim (client & candidate visit) and OT Taxi claim', 0, GETDATE(), GETDATE())