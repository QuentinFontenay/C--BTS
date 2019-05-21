-- ================================================
-- Template generated from Template Explorer using:
-- Create Inline Function (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the function.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE FUNCTION [dbo].[Nombre_De_Place]
(	
	-- Add the parameters for the function here
	@id_vol int
)
RETURNS int 
AS
 begin

    declare @nb int

	-- Add the SELECT statement with parameter references here
	SELECT @nb=(SELECT COUNT(id_billet) FROM voyage_vol 
	JOIN voyage ON voyage_vol.id_voyage=voyage.id_voyage
	JOIN billet ON voyage.id_voyage=billet.id_voyage
	WHERE id_vol=@id_vol)
	  * 100 / capacite
	FROM vol
		JOIN avion ON vol.id_avion=avion.id_avion
		JOIN modele ON modele.id_modele=avion.id_modele
	WHERE id_vol=@id_vol

	return @nb
end
GO
