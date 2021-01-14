ALTER VIEW [dbo].[V_DS_PHANMANH]
AS
SELECT TENCN=PUB.description, TENSERVER= SUBS.subscriber_server
FROM dbo.sysmergepublications PUB,  dbo.sysmergesubscriptions SUBS
WHERE PUB.pubid= SUBS.pubid AND SUBS.subscriber_server <> @@SERVERNAME AND SUBS.subscriber_server <> 'ten-cua-site-phan-manh-3' /****** (do chỉ được hiển thị 2 site lên, site 3 là site tra cứu nên không cần hiển thị) ******/
