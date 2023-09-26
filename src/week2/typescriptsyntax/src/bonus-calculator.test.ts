import { afterEach, beforeEach, describe, expect, it, vi } from "vitest";
import { calculateBonusFor } from "./bonus-calculator";

describe('Bonus Calculation', () => {

    beforeEach(() => {
        vi.useFakeTimers();
    });

    describe('Outside of Business Hours', () => {   
        
    it('Gets a bonus if balance is adequate', () => {
        const date = new Date(2023, 11, 23, 18);
        vi.setSystemTime(date);
        const bonus = calculateBonusFor(5000, 100);

        expect(bonus).toBe(10);

    })
    
    it('no bonus if balance is too low', () => {

        const bonus = calculateBonusFor(4999.99, 100);

        expect(bonus).toBe(0); 

    })
    

    });

    describe('During Business Hours', () => {

        it('Gets a bonus if balance is adequate', () => {
            const date = new Date(2023, 11, 23, 10);
            vi.setSystemTime(date);
            const bonus = calculateBonusFor(5000, 100);
    
            expect(bonus).toBe(13);
    
        })
    });
    afterEach(() => {
        vi.useRealTimers();
    })

});