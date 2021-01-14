Đồ án môn Cơ Sở Dữ Liệu Phân Tán (PTITHCM) - Đề Tài: Quản lý Vật tư - Giáo viên: thầy Kỳ Thư.


Phần mềm và các công cụ sử dụng trong đồ án:
### `SQL Server 2012 Enterprise edition`
### `DevExpress 19.2`
### `Visual Studio 2019`


Để run được project thì phải config database, sửa lại file App.config
```
<add name="VatTu.Properties.Settings.QLVT_DATHANGConnectionString"
      connectionString="Data Source=ten_subscriber_server;Initial Catalog=QLVT_DATHANG;Integrated Security=True"
      providerName="System.Data.SqlClient" />
    <add name="VatTu.Properties.Settings.QLVT_DATHANGConnectionString1"
      connectionString="Data Source=ten_subscriber_server;Initial Catalog=QLVT_DATHANG;User ID=sa;Password=123"
      providerName="System.Data.SqlClient" />
    <add name="QLVT_DATHANGConnectionString1" connectionString="XpoProvider=MSSqlServer;data source=ten_subscriber_server;user id=sa;password=123;initial catalog=QLVT_DATHANG;Persist Security Info=true" />
    <add name="VatTu.Properties.Settings.QLVT_DATHANGConnectionString2"
      connectionString="Data Source=ten_subscriber_server;Initial Catalog=QLVT_DATHANG;User ID=sa;Password=123"
      providerName="System.Data.SqlClient" />
```
ten_subscriber_server: check bằng lệnh SELECT * FROM dbo.sysmergesubscriptions trong SQL Server (query ở ngay csdl Vật tư thì nó mới work).

Database:
![alt text](img/publi.PNG?raw=true)
![alt text](img/filter.PNG?raw=true)
![alt text](img/site3.PNG?raw=true)

