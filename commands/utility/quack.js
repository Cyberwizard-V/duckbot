const { SlashCommandBuilder } = require('discord.js');
const { getRandomInt } = require('../../shared/sharedfunctions.js');

const quack = ['QUACK!', 'WHAT THE QUACK!', 'WHAT THE DUCK?!', 'Wassduck?', 'Ducky duck'];

module.exports = {
	data: new SlashCommandBuilder()
		.setName('quack')
		.setDescription('Replies with quack!'),
	async execute(interaction) {
		await interaction.reply(quack[getRandomInt(quack.length)]);
	},
};