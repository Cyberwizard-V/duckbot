const { SlashCommandBuilder } = require('discord.js');
const { getDuckGif } = require('../../api/duckgif.js');

const quack = ['QUACK!', 'WHAT THE QUACK!', 'WHAT THE DUCK?!', 'Wassduck?'];

function getRandomInt(max) {
	return Math.floor(Math.random() * max);
}
module.exports = {
	data: new SlashCommandBuilder()
		.setName('quack')
		.setDescription('Replies with quack!'),
	async execute(interaction) {
		await interaction.reply(quack[getRandomInt(quack.length)]);
	},
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