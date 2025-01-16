namespace coursework_project
{
    internal class Combat_Calculations
    {
        public static float Fluff_Health_Potion_Amount(Item potion)
        {
            float recovery_amount = potion.Get_Health_Recovery();

            Random rng = new Random();

            float modifier = get_Damage_Modifier();

            recovery_amount *= modifier;
            return recovery_amount;
        }
        public static void Enemy_Turn(Enemy enemy)
        {
            Random rng = new Random();
            int damage_choice = rng.Next(1, 2);

            int modifier = get_Damage_Modifier();

            int base_damage;
            int total_damage = base_damage + modifier;

            if (damage_choice == 1)
            {
                base_damage = enemy.Get_Damage_1_type();
                Display_text_func.Display_Text_Continued("The " + enemy.Get_Name() + " goes in for a light attack");
            }

            else
            {
                base_damage = enemy.Get_Damage_2_type();
                Display_text_func.Display_Text_Continued("The " + enemy.Get_Name() + " goes in for a heavy attack and deals ");
            }




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

        }
    }



}