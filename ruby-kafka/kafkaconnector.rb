require "kafka"
kafka = Kafka.new(
    ["localhost:9092"]
    )
producer = kafka.producer
producer.produce("test message1",topic: "message_logs")
producer.produce("test message2",topic: "message_logs")
producer.produce("test message3",topic: "message_logs")
producer.produce("test message4",topic: "message_logs")
producer.deliver_messages
print "messages published to borker"