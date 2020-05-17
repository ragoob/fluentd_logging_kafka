
require "kafka"
kafka = Kafka.new(
 [ARGV[0]]
    )

consumer = kafka.consumer(group_id: ARGV[1]
)
consumer.subscribe("message_logs")
trap("TERM") { consumer.stop }
consumer.each_message do |message|
  puts message.topic, message.partition
  puts message.offset, message.key, message.value
end
