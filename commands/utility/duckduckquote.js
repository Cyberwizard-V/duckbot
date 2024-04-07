const { SlashCommandBuilder } = require('discord.js');
const { Duck_quotes } = require('../../data/duckquotes.json');
const { getRandomInt } = require('../../shared/sharedfunctions.js');
const { EmbedBuilder } = require('discord.js');

// Emoji's
const emojis = ['🦆', '🐥', '🐣', '🐤', '🥚', '🌾', '🌻', '🌿', '💧'];

module.exports = {
	data: new SlashCommandBuilder()
		.setName('duckduckquote')
		.setDescription('Replies with a duck quote'),
	async execute(interaction) {
		try {
			const randomQuote = Duck_quotes[getRandomInt(Duck_quotes.length)];

			const embed = new EmbedBuilder()
				.setThumbnail('https://i.imgur.com/ryjpL39.png')
				.setColor('#0099ff')
				.setTitle('🦆 ' + 'Duck Quote')
				.setDescription(randomQuote + ' ' + emojis[getRandomInt(emojis.length)])
				.setTimestamp()
				.setFooter({ text: 'Quackwise', iconURL: 'https://i.imgur.com/ryjpL39.png' });

			await interaction.reply({ embeds: [embed] });
		}
		catch (error) {
			console.error(error);
			await interaction.reply('Seems like the quote is not loading... what the duck.. -');
		}
	},
};