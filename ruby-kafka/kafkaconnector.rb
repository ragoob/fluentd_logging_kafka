
require "kafka"
kafka = Kafka.new(
 [ARGV[0]]
    )

    # Consumers with the same group id will form a Consumer Group together.
consumer = kafka.consumer(group_id: ARGV[1]
)

# It's possible to subscribe to multiple topics by calling `subscribe`
# repeatedly.
consumer.subscribe("message_logs")

# Stop the consumer when the SIGTERM signal is sent to the process.
# It's better to shut down gracefully than to kill the process.
trap("TERM") { consumer.stop }

# This will loop indefinitely, yielding each message in turn.
consumer.each_message do |message|
  puts message.topic, message.partition
  puts message.offset, message.key, message.value
end
