﻿CREATE TABLE [dbo].[Booking]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Nights] INT NOT NULL,
	[TamagotchiId] INT NOT NULL,
	[HotelroomId] INT NOT NULL,
	CONSTRAINT [fk_tamagotchi_hotelroom] FOREIGN KEY (TamagotchiId) REFERENCES [Tamagochis](Id),
	CONSTRAINT [fk_hotelroom_tamagotchi] FOREIGN KEY (HotelroomId) REFERENCES [Hotelrooms](Id)
)