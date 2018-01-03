CREATE TABLE [dbo].[Booking]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Start] DATETIME NOT NULL,
	[End] DATETIME NULL,
	[TamagotchiId] INT NOT NULL,
	[HotelroomId] INT NOT NULL,
	CONSTRAINT [fk_tamagotchi_hotelroom] FOREIGN KEY (TamagotchiId) REFERENCES [Tamagochi](Id),
	CONSTRAINT [fk_hotelroom_tamagotchi] FOREIGN KEY (HotelroomId) REFERENCES [Hotelroom](Id)
)
