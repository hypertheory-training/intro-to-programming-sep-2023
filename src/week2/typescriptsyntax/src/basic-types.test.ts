import { describe, expect, it } from 'vitest';


describe('Types in TypeScript', () => {

    describe('Implicit Typing', () => {
        it('An Example', () => {
            let a = 10, b = 20, answer;

            answer = a + b;

            expect(answer).toBe(30);
        })
        it('Implicit Typing When you Initialize a Variabe', () => {

            type AgeType = 'Minor' | 'Adult'; // Type Alias
            let age: number | AgeType = 54; // age can be either a number or AgeType

            age = 'Adult';

            expect(age).toBe('Adult');


            let name: string;

            name = 'Pedro';

            // name = 1338;
            expect('tacos').toEqual("tacos");

            let myLifeStory = `Chapter 1
            It was a dark and stormy night.

            The End
            `;

            expect(`The name is ${name} and they are ${age}`).toBe('The name is Pedro and they are Adult');

        });

        it('For arrays', () => {
            let ingredients: (number | string)[];

            let colors: Array<string>;

            ingredients = ['Water', 'Egg', 13];

            expect(ingredients[0]).toBe('Water');

            expect(ingredients[809]).toBeUndefined();
            ingredients[810] = 'Beer';



        });
    })

    describe('Structural Typing', () => {
        it('An example ofr structural typing', () => {


            let joe = {
                name: 'Joseph',
                sendReminder(message: string) {
                    console.log('Sent me a ' + message)
                },
                age: 32,
                email: 'joe@aol.com'
            }

            sendReminder(joe, "Build Something");
            var vinny = new Worker();
            sendReminder(vinny, 'Do Some Stuff')

            //interface IRemindable 

            function sendReminder(who: { name: string, sendReminder: (what: string) => void }, message: string) {
                console.log('Sending a reminder to ' + who.name);
                who.sendReminder('Your Reminder: ' + message);
            }
        });
    })


})

class Worker {
    get name() {
        return 'Vinny'
    }

    sendReminder(what: string) {
        // do the thing
    }
    sendBonus(amount:number) {

    }
}