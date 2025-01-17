namespace coursework_project
{
    internal class Combat_Calculations
    {
        public static int Fluff_Health_Potion_Amount(Item potion)
        {
            int recovery_amount = potion.Get_Health_Recovery();

            Random rng = new Random();

            int modifier = get_Damage_Modifier();

            recovery_amount += modifier;
            return recovery_amount;
        }
        public static void Enemy_Turn(Enemy enemy)
        {
            Random rng = new Random();
            int attack_choice = rng.Next(1, 3);

            int modifier = get_Damage_Modifier();

            int base_damage;

            if (attack_choice == 1)
                base_damage = enemy.Get_Damage_1_type();

            else
                base_damage = enemy.Get_Damage_2_type();

            int total_damage = base_damage + modifier;

            File_Load.sound_player_take_damage.Play();
            Display_text_func.Display_Text_Continued("The " + enemy.Get_Name() + " is going in for a " + $"{(attack_choice == 1 ? "Light " : "Heavy ")}" 
                + "attack and just hit you for " + total_damage + " damage!");


            Program.current_player.Take_Damage(total_damage);

        }
        private static int get_Damage_Modifier()
        {
            Random rng = new Random();
            int modifier = rng.Next(-3, 3);

            return modifier;
        }
        public static void Damage_Enemy(Item weapon, Enemy enemy)
        {
            int modifier = get_Damage_Modifier();

            int total_damage = weapon.Get_Base_Damage() + modifier;

            enemy.Take_Damage(total_damage);

            Display_text_func.Display_Text_Continued("You just hit the " + enemy.Get_Name() + " for " + total_damage + " damage!");

        }
    }



}