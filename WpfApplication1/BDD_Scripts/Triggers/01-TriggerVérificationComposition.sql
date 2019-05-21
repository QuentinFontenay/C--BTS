--====================================
--  Create database trigger template 
--====================================
USE AirAtlantique
GO
CREATE TRIGGER Verification_de_la_composition_des_vols ON voyage_vol AFTER INSERT
AS 

Declare @idvoyage int

DECLARE voyage CURSOR FOR
SELECT id_voyage from inserted

OPEN voyage

FETCH NEXT FROM voyage INTO @idvoyage

WHILE @@FETCH_STATUS = 0
BEGIN
Declare @dateD datetime
Declare @dateA datetime
Declare @next datetime
Declare @count int

SELECT @count = COUNT(id_vol) FROM voyage_vol WHERE id_voyage = @idvoyage

	IF @count > 1
	BEGIN
		DECLARE dateduo CURSOR FOR
		SELECT dateDTheo, DATEADD(hour, 1, dateATheo) FROM voyage_vol JOIN vol ON voyage_vol.id_vol=vol.id_vol WHERE id_voyage = @idvoyage ORDER BY dateDTheo
		OPEN dateduo
		FETCH NEXT FROM dateduo INTO @next, @dateA 
		FETCH NEXT FROM dateduo INTO @dateD, @next
			IF @dateA > @dateD
			BEGIN
				PRINT 'Les vols sont trop raproché pour être ajouter au voyage' + @idvoyage
				ROLLBACK TRANSACTION
			END
		WHILE @@FETCH_STATUS = 0
		BEGIN
			SET @dateA = @next
			FETCH NEXT FROM dateduo INTO @dateD, @next
			IF @dateA > @dateD
			BEGIN
				PRINT 'Les vols sont trop raproché pour être ajouter au voyage' + @idvoyage
				ROLLBACK TRANSACTION
			END
		END
		CLOSE dateduo
		DEALLOCATE dateduo
	END
END