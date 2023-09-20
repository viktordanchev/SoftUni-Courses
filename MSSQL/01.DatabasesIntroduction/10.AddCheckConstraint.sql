ALTER TABLE [Users]
	ADD CONSTRAINT CK__Users__Password__3B40CD36 CHECK ([Password] >= 5)