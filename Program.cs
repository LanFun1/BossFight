using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BossFight
{
    class Program
    {
        static void Main(string[] args)
        {
            int characterHealth = 100;
            int bossHealth = 250;
            int tornadoDuration = 0;
            int bossDamage = 40;
            int tornadoDamage = 35;
            int fireballDamage = 50;
            int lagunaDamage = 30;
            int bulletDamage = 40;
            bool chargesLightning = true;
            int stunDuration = 0;
            Console.WriteLine("Здравствуйте, герой! Вы были перенесены в этот мир, чтобы спасти его! Вам предстоит сразиться с тёмным магом. Вам также будет дарована магия. У вас есть 4 способности.\nПервая способность - это торнадо, для призыва вам необходимо произнести Tornado(урон наносится 2 хода(по 35 урона)).\nВторая способность - это огненный шар, для призыва вам необходимо произнести FireBall(при использовании после с торнадо нанесёт двойной урон, а также прекратит эффект торнадо).\nТретья способность - это удар молнии, для использования необходимо произнести LagunaBlade.(Может быть использован единожды и отнимает четверть вашего нынешнего здоровья, а также не может быть применён в торнадо. Станит врага на 2 хода).\nЧетвёртая способность - каменная пуля, для использования необходимо произнести StoneBullet(также не может быть использована в торнадо.)");
            Console.WriteLine("Бой начался! Вы атакуете первым.");
            string spellName = "";
            while(characterHealth>0 && bossHealth>0)
            {
                spellName = Console.ReadLine();
                switch(spellName)
                {
                    case "Tornado":
                        tornadoDuration = 2;
                        break;
                    case "FireBall":
                        if(tornadoDuration > 0)
                        {
                            bossHealth -= fireballDamage * 2;
                            tornadoDuration = 0;
                        }
                        else
                        {
                            bossHealth -= fireballDamage;
                        }
                        break;
                    case "LagunaBlade":
                        if(tornadoDuration > 0 || chargesLightning == false)
                        {
                            bossHealth -= 0;
                        }
                        else if(tornadoDuration == 0 && chargesLightning== true)
                        {
                            bossHealth -= lagunaDamage;
                            stunDuration = 2;
                            chargesLightning = false;
                        }
                        break;
                    case "StoneBullet":
                        if(tornadoDuration>0)
                        {
                            bossHealth -= 0;
                        }
                        else
                        {
                            bossHealth -= bulletDamage;
                        }
                        break;
                }     
                if(tornadoDuration >0)
                {
                    tornadoDuration -= 1;
                    bossHealth -= tornadoDamage;
                }
                if(stunDuration == 0)
                {
                    characterHealth -= bossDamage;
                }
                Console.WriteLine($"Здоровье героя: {characterHealth}\nЗдоровье босса: {bossHealth}");
            }
            if(characterHealth <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Вы проиграли!");
            }
            if(bossHealth<= 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Поздравляю! Вам удалось победить!");
            }
        }
    }
}
