### Using Fluentd to read logs from Kafka and log to Elastic search or files based on Kafka Topic 

![alt text](https://github.com/ragoob/fluentd_logging_kafka/blob/master/Digram22.png?raw=true)

 #### Run 
  sudo docker-compose --f docker-compose-fluentd.yml up --build
 #### Notes :
  - Elastic search need at least 2 GB of memory 
  - do not use kafka inside docker in production
  
