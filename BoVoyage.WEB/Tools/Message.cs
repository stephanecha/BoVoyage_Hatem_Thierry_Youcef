namespace BoVoyage.WEB.Tools
{
	public enum MessageType : byte
	{
		SUCCESS,
		ERROR
	}

	public sealed class Message
	{
		public string MessageType { get; private set; }
		public string Text { get; set; }

		public Message(string text, MessageType messageType)
		{
			if (messageType == Tools.MessageType.SUCCESS)
				this.MessageType = "success";
			else
				this.MessageType = "danger";
			this.Text = text;
		}
	}
}