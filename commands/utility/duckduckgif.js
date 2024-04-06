const { SlashCommandBuilder } = require('discord.js');
const { getDuckGif } = require('../../api/duckgif.js');

module.exports = {
	// eslint-disable-next-line no-dupe-keys
	data: new SlashCommandBuilder()
		.setName('duckduckgif')
		.setDescription('Replies with duck gif'),
	// eslint-disable-next-line no-dupe-keys
	async execute(interaction) {
		try {
			const gifUrl = await getDuckGif();
			await interaction.reply(gifUrl);
		}
		catch (error) {
			console.error(error);
			await interaction.reply('SORRY! SEEMS LIKE THE API IS NOT WORKING?!');
		}
	},
};