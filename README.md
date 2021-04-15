# Đồ án môn Cơ Sở Dữ Liệu Phân Tán (PTITHCM) - Đề Tài: Quản lý vật tư.


## Phần mềm và các công cụ sử dụng trong đồ án:
### `SQL Server 2012 Enterprise edition`
### `DevExpress 19.2`
### `Visual Studio 2019`

Để run được project thì phải config database, sửa lại file App.config
```
<add name="VatTu.Properties.Settings.QLVT_DATHANGConnectionString"
      connectionString="Data Source=ten_subscriber_server_chủ;Initial Catalog=QLVT_DATHANG;Integrated Security=True"
      providerName="System.Data.SqlClient" />
    <add name="VatTu.Properties.Settings.QLVT_DATHANGConnectionString1"
      connectionString="Data Source=ten_subscriber_server_1;Initial Catalog=QLVT_DATHANG;User ID=sa;Password=123"
      providerName="System.Data.SqlClient" />
    <add name="QLVT_DATHANGConnectionString1" connectionString="XpoProvider=MSSqlServer;data source=ten_subscriber_server_1;user id=sa;password=123;initial catalog=QLVT_DATHANG;Persist Security Info=true" />
    <add name="VatTu.Properties.Settings.QLVT_DATHANGConnectionString2"
      connectionString="Data Source=ten_subscriber_server_chủ;Initial Catalog=QLVT_DATHANG;User ID=sa;Password=123"
      providerName="System.Data.SqlClient" />
```
1. *ten_subscriber_server: check bằng lệnh SELECT * FROM dbo.sysmergesubscriptions trong SQL Server (query ở ngay csdl Vật tư thì nó mới work).*
2. *ten_subscriber_server_1: là tên subscriber_server của site 1*
3. *ten_subscriber_server_chủ: là tên subscriber_server của tên chủ*

## Chức năng
- Đầy đủ các chức năng cơ bản (thêm, xóa, sửa, reload, chuyển chi nhánh).
- UNDO: khôi phục lại dữ liệu (tương tự như trong Word).
- Lập các phiếu và chi tiết các phiếu.
- Tạo tài khoản.
- 6 báo cáo (Store Procedure trong folder database).

## Database

3 site phân mảnh.

![alt text](img/publi.PNG?raw=true)



Cây dẫn xuất của site 1 và 2

![alt text](img/filter.PNG?raw=true)



Articles của site 3

![alt text](img/site3.PNG?raw=true)



Một số hình ảnh


![alt text](img/1.PNG?raw=true)


![alt text](img/2.PNG?raw=true)


![alt text](img/3.PNG?raw=true)


![alt text](img/kho.PNG?raw=true)


![alt text](img/nhanvien.PNG?raw=true)


![alt text](img/4.PNG?raw=true)


## Bugs :bug:
> Đồ án sẽ có một số lỗi mà mình chưa fix (lỗi khi thoát khỏi form Login để tắt chương trình, lỗi khi nhập Phiếu Nhập, lỗi chuyển chi nhánh,...). Bên cạnh đó, giao diện đồ án này chỉ phù hợp với laptop có độ phân giải fullHD =)), nên đôi khi bạn phải chỉnh lại chút xíu).



## Lời Khuyên
> Để lại tin nhắn vào mục [Issues](https://github.com/itialan/QuanLyVatTu_CSDLPT_PTITHCM/issues) nếu bạn cần giúp đỡ. Và hãy star vì nó miễn phí :(

> HIỂU BÀI VÀ LÀM BÀI, QUAN TRỌNG NHẤT VẪN LÀ LÝ THUYẾT TRÊN LỚP :)



## Contributors :guardsman:
<a href="https://github.com/QuangHuy239/QLVT_DATHANG/graphs/contributors">
  <img src="https://contrib.rocks/image?repo=QuangHuy239/QLVT_DATHANG" />
</a>



## Video :tv:
https://www.youtube.com/watch?v=jBkZzBGdkMw
