#version 330 core

out vec4 FragColor;
in vec2 Pos;
in vec2 stand;
in vec2 screen;
uniform float iTime;

#define t iTime
#define r screen.xy

void main(){
vec3 c;
	float l,z=t;
	for(int i=0;i<3;i++) {
		vec2 uv,p=Pos.xy/r;
		uv=p;
		p-=.5;
		p.x*=r.x/r.y;
		z+=.07;
		l=length(p);
		uv+=p/l*(sin(z)+1.)*abs(sin(l*9.-z-z));
		c[i]=.01/length(mod(uv,1.)-.5);
	}
	FragColor=vec4(c/l,t);

}