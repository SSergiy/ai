ai SS 2013

 Erstmalige Installation 

* Microsoft Visual Studio 2010 mit Service Pack 1
* Nuget Installieren <code>http://msdn.microsoft.com/de-de/magazine/hh547106.aspx</code>
* Fluent NHibernate installieren <code>Install-Package FluentNHibernate </code>
* SQLite installieren <code>Install-Package System.Data.SQLite</code>
* NHibernate LINQ <code>Install-Package NHibernate.Linq</code>
* Log4Net <code>Install-Package log4net</code>
* MySql <code>Install-Package MySql.Data</code>
* ServiceStack.Text (JSON (De)Serializer )<code>Install-Package ServiceStack.Text</code>
* RabbitMQ - Server <code>http://www.rabbitmq.com/download.html</code>
* RabbitMQ Server starten: "C:\Program Files (x86)\RabbitMQ Server\rabbitmq_server-3.1.1\sbin\rabbitmq-server.bat" 
* Es bietet sich alternativ an RabbitMQ und Mysql über vagrant zu starten. Dafür nach /Server wechselt und <code>vagrant up</code> eingeben. 
** Unter Umständig muss Erlang in der Firewall als Außnahme eingestellt werden(RabbitMQ ist in Erlang implementiert)
* RabbitMQ .NET 3.0+ Client - Bestandteil von RabbitMQ Test <code>http://www.rabbitmq.com/releases/rabbitmq-dotnet-client/v3.1.1/rabbitmq-dotnet-client-3.1.1-dotnet-3.0.zip</code> enthält ebenfalls Beispielcode zum Umgang mit RabbitMQ
** Beispiel Anwendung für RabbitMQ in der Solution "RabbitMQTest"
Als Graph Tool wird Yed benutzt: <code>http://www.yworks.com/de/products_yed_about.html</code>