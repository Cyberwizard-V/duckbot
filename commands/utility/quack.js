const { SlashCommandBuilder } = require('discord.js');

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
};