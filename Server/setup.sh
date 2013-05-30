#### rabbitmq
cat >> /etc/apt/sources.list <<EOT
deb http://www.rabbitmq.com/debian/ testing main
EOT

wget http://www.rabbitmq.com/rabbitmq-signing-key-public.asc
apt-key add rabbitmq-signing-key-public.asc

apt-get update

# apt-get install -q -y screen htop vim curl wget
apt-get install -q -y rabbitmq-server

# RabbitMQ Plugins
service rabbitmq-server stop
rabbitmq-plugins enable rabbitmq_management
rabbitmq-plugins enable rabbitmq_jsonrpc
service rabbitmq-server start

# rabbitmq-plugins list


#### mysql
sudo apt-get update
sudo debconf-set-selections <<< 'mysql-server-5.1 mysql-server/root_password password root'
sudo debconf-set-selections <<< 'mysql-server-5.1 mysql-server/root_password_again password root'
sudo apt-get install mysql-server-5.1 mysql-client -y -q

sudo sed -i 's/127.0.0.1/0.0.0.0/g' /etc/mysql/my.cnf

MYSQL=`which mysql`
Q1="CREATE DATABASE IF NOT EXISTS hesdb;"
Q2="GRANT ALL ON *.* TO 'root'@'%' IDENTIFIED BY 'root';"
Q3="FLUSH PRIVILEGES;"
SQL="${Q1}${Q2}${Q3}"

$MYSQL -uroot -proot -e "$SQL"

sudo service mysql restart