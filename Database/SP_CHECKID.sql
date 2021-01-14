ALTER PROCEDURE [dbo].[SP_CHECKID]
@Code NVARCHAR(15), @Type NVARCHAR(15)
AS
BEGIN
	-- Nhân viên
	IF(@Type = 'MANV')
	BEGIN
		IF EXISTS(SELECT * FROM dbo.NhanVien WHERE dbo.NhanVien.MANV = @Code)
			RETURN 1; -- Mã NV tồn tại ở phân mảnh hiện tại
		ELSE IF EXISTS(SELECT * FROM LINK1.QLVT_DATHANG.dbo.NhanVien AS NV WHERE NV.MANV = @Code)
			RETURN 2; -- Mã NV tồn tại ở phân mảnh khác
	END

	-- Kho
	IF(@Type = 'MAKHO')
	BEGIN
		IF EXISTS(SELECT * FROM dbo.Kho WHERE dbo.Kho.MAKHO = @Code)
			RETURN 1; -- Mã kho tồn tại ở phân mảnh hiện tại
		ELSE IF EXISTS(SELECT * FROM LINK1.QLVT_DATHANG.dbo.Kho AS KHO WHERE KHO.MAKHO = @Code)
			RETURN 2; -- Mã Kho tồn tại ở phân mảnh khác
	END
	IF(@Type = 'TENKHO')
	BEGIN
		IF EXISTS(SELECT * FROM dbo.Kho WHERE dbo.Kho.TENKHO = @Code)
			RETURN 1; -- Tên kho tồn tại ở phân mảnh hiện tại
		ELSE IF EXISTS(SELECT * FROM LINK1.QLVT_DATHANG.dbo.Kho AS KHO WHERE KHO.TENKHO = @Code)
			RETURN 2; -- Tên Kho tồn tại ở phân mảnh khác
	END

	-- Đặt hàng
	IF(@Type = 'MasoDDH')
	BEGIN
		IF EXISTS(SELECT * FROM dbo.DatHang WHERE dbo.DatHang.MasoDDH = @Code)
			RETURN 1; -- Mã DDH tồn tại ở phân mảnh hiện tại
		ELSE IF EXISTS(SELECT * FROM LINK1.QLVT_DATHANG.dbo.DatHang AS DH WHERE DH.MasoDDH = @Code)
			RETURN 2; -- Mã DDH tồn tại ở phân mảnh khác
	END

	-- Phiếu Xuất
	IF(@Type = 'MAPX')
	BEGIN
		IF EXISTS(SELECT * FROM dbo.PhieuXuat WHERE dbo.PhieuXuat.MAPX = @Code)
			RETURN 1; -- Mã PX tồn tại ở phân mảnh hiện tại
		ELSE IF EXISTS(SELECT * FROM LINK1.QLVT_DATHANG.dbo.PhieuXuat AS PX WHERE PX.MAPX = @Code)
			RETURN 2; -- Mã PX tồn tại ở phân mảnh khác
	END

	-- Phiếu Nhập
	IF(@Type = 'MAPN')
	BEGIN
		IF EXISTS(SELECT * FROM dbo.PhieuNhap WHERE dbo.PhieuNhap.MAPN = @Code)
			RETURN 1; -- Mã PN tồn tại ở phân mảnh hiện tại
		ELSE IF EXISTS(SELECT * FROM LINK1.QLVT_DATHANG.dbo.PhieuNhap AS PN WHERE PN.MAPN = @Code)
			RETURN 2; -- Mã PN tồn tại ở phân mảnh khác
	END

	-- Vật tư, chỉ cần check ở site hiện tại
	IF(@Type = 'MAVT')
	BEGIN
		IF EXISTS(SELECT * FROM dbo.Vattu WHERE MAVT = @Code)
		RETURN 1;
	END

	RETURN 0 -- Không bị trùng
END
