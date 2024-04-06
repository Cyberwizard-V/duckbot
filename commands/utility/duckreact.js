const { SlashCommandBuilder } = require('discord.js');

module.exports = {
	data: new SlashCommandBuilder()
		.setName('Duck')
		.setDescription('Replies with a quack!'),
	async execute(interaction) {
		await interaction.reply('QUACK!');
	},
};